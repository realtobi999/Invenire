from faker import Faker
from datetime import timedelta, timezone
import uuid
import random
import json

PROPERTY_ID = "9a1b0126-710d-47c1-aa76-8f140a9f34b6"
EMPLOYEES_IDS = ["5aa2972d-13f7-43e5-bfbf-6f6c001466e7"]

fake = Faker("cs_CZ")


def iso_datetimeoffset(dt):
    if dt.tzinfo is None:
        dt = dt.replace(tzinfo=timezone.utc)
    return dt.isoformat(timespec="milliseconds")


def fake_property_item():
    purchase_date = fake.date_time_this_decade(tzinfo=timezone.utc)
    sale_date = purchase_date + timedelta(days=random.randint(30, 1000)) if random.choice([True, False]) else None

    return {
        "property_id": PROPERTY_ID,
        "employee_id": random.choice(EMPLOYEES_IDS) if random.choice([True, False]) else None,
        "inventory_number": f"INV-{fake.unique.random_int(1000, 999999)}",
        "registration_number": f"REG-{fake.unique.random_int(1000, 999999)}",
        "name": fake.word().capitalize(),
        "price": round(random.uniform(1000, 100000), 2),
        "serial_number": fake.bothify(text="SN-####-????") if random.choice([True, False]) else None,
        "date_of_purchase": iso_datetimeoffset(purchase_date),
        "date_of_sale": iso_datetimeoffset(sale_date) if sale_date else None,
        "location": {
            "room": f"{fake.random_int(1, 50)}",
            "building": f"{fake.random_int(1, 10)}",
            "additional_note": fake.sentence(nb_words=5) if random.choice([True, False]) else None,
        },
        "description": fake.text(max_nb_chars=50),
        "document_number": f"DOC-{fake.random_int(1000, 9999)}",
        "created_at": iso_datetimeoffset(fake.date_time_this_year(tzinfo=timezone.utc)),
        "last_updated_at": iso_datetimeoffset(fake.date_time_this_month(tzinfo=timezone.utc)) if random.choice([True, False]) else None,
    }


items = [fake_property_item() for _ in range(1000)]

data = {"items": items}

with open("property_items.json", "w", encoding="utf-8") as f:
    json.dump(data, f, ensure_ascii=False, indent=2)

print("Saved property_items.json with", len(items), "items")
