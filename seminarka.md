# Invenire

## Úvod

Cílem mé práce bylo navrhnout a realizovat webovou aplikaci, která sjednotí správu majetku do jednoho systému, nabídne inventarizaci pomocí QR kódů a umožní bezpečný přístup podle rolí.

Správa majetku je v organizacích důležitá, protože ovlivňuje finanční přehled, odpovědnost zaměstnanců a schopnost rychle ověřit, co firma skutečně vlastní. Pokud se evidence vede v roztříštěných tabulkách, vznikají chyby, duplicity a neaktuální informace, které se naplno projeví při inventurách. Téma této práce je proto významné z praktického i společenského hlediska: dobře navržený systém šetří čas, snižuje ztráty a zvyšuje důvěru v data.

Mou motivací k vytvoření této aplikace bylo především to, že mi přišla nejzajímavější ze všech nabízených prací a vidím v ní potenciál jako reálný a prakticky využitelný nástroj. Zároveň věřím, že tato práce bude reprezentativní a přispěje k mému budoucímu uplatnění v oboru programování.

## 1. Teoretická část

### 1.1 Historie a kontext

Správa majetku se historicky vyvíjela z jednoduchých inventárních knih, které obsahovaly přehled o věcech, jejich hodnotě a umístění. Důvod byl praktický: organizace potřebovala mít přehled o tom, co vlastní, kdo majetek používá a jaký je jeho stav. Tento model byl dlouhá léta postaven na papírových evidencích, což s rostoucím množstvím položek přineslo zásadní problémy – dokumenty se ztrácely, data nebyla aktuální a inventura byla časově náročná i náchylná k chybám.

S rozšířením kancelářského softwaru došlo k přechodu na tabulkové procesory. Tento krok sice zjednodušil základní evidenci, ale nevyřešil problém vícenásobných verzí a nedostatku kontroly. Tabulky často spravoval jediný člověk, který je sdílel e‑mailem, nebo byly uloženy na síťovém disku, kde se současně pracovalo s několika kopiemi. V okamžiku, kdy bylo nutné provést inventuru, nebylo možné zaručit, že používaná tabulka odpovídá realitě. I drobné změny, jako přesun majetku mezi místnostmi, se často nezaznamenaly včas.

Dalším historickým krokem byla centralizace evidencí do databází a zavedení lokálních informačních systémů. Tyto systémy přinesly výhodu jednoho centrálního zdroje dat, ale zároveň byly často uzavřené, svázané s konkrétním hardwarem nebo dostupné jen z lokální sítě. V praxi to znamenalo, že správa byla sice přesnější, ale využitelnost systému v terénu byla omezená. V době, kdy se organizace začaly spoléhat na mobilní zařízení a flexibilní pracovní režimy, se ukázalo, že tradiční desktopové aplikace nejsou dostatečně pružné.

V současnosti se proto posouváme k webovým systémům, které umožňují přístup odkudkoli, mají jasně definované rozhraní a podporují integraci s dalšími nástroji. Webová aplikace je schopna obsloužit více rolí, nabízí centrální řízení přístupů a usnadňuje sdílení dat v reálném čase. Navíc umožňuje implementovat moderní mechanismy jako je auditní stopa, notifikace nebo automatické čištění neaktuálních záznamů.

Důležitým faktorem současného vývoje je i důraz na rychlost inventur. Inventura v praxi často znamená fyzickou kontrolu stovek až tisíců položek, která je bez technické podpory neefektivní. Zavedení čárových nebo QR kódů umožnilo okamžitou identifikaci položky a propojení se systémem. Tím se zkrátila doba inventury, snížil počet chyb a zlepšila možnost zpětné kontroly. V kontextu školních organizací nebo menších firem představuje QR kód cenově dostupný a technicky nenáročný nástroj, který má vysoký praktický přínos.

Kromě inventur se mění i očekávání v oblasti přidělování majetku. Dříve byla běžná situace, kdy nebylo jasné, kdo konkrétní majetek používá, a odpovědnost byla rozptýlená. Moderní systém by měl podporovat přiřazení položek konkrétním zaměstnancům, udržovat historii změn a poskytovat přehled o tom, kdy a kým byl majetek převzat nebo vrácen. Takový přístup zvyšuje odpovědnost jednotlivců a zároveň usnadňuje kontrolu.

Z kontextu vyplývá, že správa majetku není pouze technickou evidencí, ale procesem, který ovlivňuje každodenní chod organizace. Informační systém musí proto reagovat na potřebu transparentnosti, rychlosti a dostupnosti. Zároveň musí být robustní vůči chybám, protože každý záznam o majetku představuje konkrétní finanční hodnotu.

Projekt Invenire se do tohoto kontextu řadí jako moderní webové řešení, které kombinuje přehlednou evidenci, uživatelské role, inventury a automatizované procesy. Historický vývoj ukazuje, že bez kvalitního systému roste provozní riziko a klesá důvěra v data. Smyslem aplikace je toto riziko minimalizovat a poskytnout organizacím nástroj, který je udržitelný i do budoucna.

### 1.2 Teoretická východiska

Základním teoretickým rámcem aplikace Invenire je architektura klient–server. Tato architektura umožňuje oddělit zodpovědnosti: server spravuje data a logiku, klient zajišťuje uživatelské rozhraní a interakci. Díky tomuto rozdělení lze nezávisle rozvíjet frontend i backend a zároveň podporovat více typů klientů. Klient komunikuje se serverem pomocí HTTP, což zaručuje standardizovaný a dobře podporovaný komunikační kanál.

Konkrétní implementace webových služeb v Invenire vychází z principů REST. REST je architektonický styl, jehož cílem je dosažení škálovatelnosti, obecnosti rozhraní a nezávislého nasazování komponent; důležitou roli hrají i prostředníci, kteří zlepšují bezpečnost a výkon systému. (ics.uci.edu) V praxi se to projevuje tím, že server pracuje se zdroji (resources), které jsou jednoznačně identifikovány, a klient s nimi manipuluje pomocí standardních operací. REST definuje jednotné rozhraní, v němž jsou zdroje identifikovány, jejich stav je reprezentován přenášenými reprezentacemi a zprávy jsou samopopisné; zásadní je i princip hypermedia jako řídící mechanismus stavu aplikace. (ics.uci.edu) Tento model umožňuje, aby API bylo čitelné, konzistentní a snadno rozšiřitelné.

V REST modelu je důležitá i bezestavovost (stateless). Server si neuchovává kontext klienta mezi jednotlivými požadavky a každý požadavek musí obsahovat všechny potřebné informace. Tento princip zjednodušuje škálování a zvyšuje spolehlivost, protože server není závislý na konkrétním spojení. Z hlediska správy majetku to znamená, že například požadavek na vytvoření nové položky majetku obsahuje vše, co server potřebuje pro její uložení, a není závislý na předchozích krocích.

S RESTem souvisí i návrh endpointů a použití HTTP metod. Operace jako vytvoření, čtení, aktualizace a mazání se mapují na metody POST, GET, PUT a DELETE. Takové mapování zajišťuje konzistentní rozhraní a zároveň využívá standardní semantiku webu. V praxi to podporuje pochopitelnost API a usnadňuje jeho testování (například pomocí Swagger UI).

Dalším klíčovým teoretickým východiskem je autentizace a autorizace. Invenire používá model založený na JWT. JWT je kompaktní, URL‑safe způsob reprezentace claimů, které se přenášejí mezi dvěma stranami, a může být digitálně podepsán či šifrován, aby byla zajištěna integrita a případně důvěrnost. (rfc-editor.org) V rámci systému JWT zajišťuje, že server dokáže ověřit identitu uživatele bez potřeby ukládat stav na serveru. Součástí tokenu jsou role a ověřovací informace, které rozhodují o tom, zda má uživatel přístup k administrátorským operacím nebo pouze k funkcím zaměstnance.

Teoreticky důležitý je také koncept rolí a politik. V systému existují odlišné role (admin a employee), které určují, jaké operace jsou povoleny. Politiky kombinují role s dalšími atributy, například stavem ověření e‑mailu. Tento přístup je v kontextu správy majetku zásadní, protože administrátor musí mít plný přístup k evidenci a inventurám, zatímco zaměstnanec má mít přístup pouze k částem, které se týkají jeho pracovních povinností.

Další teoretickou oblastí je datové modelování. Správa majetku vyžaduje jednoznačné vazby mezi položkami, organizacemi a uživateli. Relační databáze je v tomto směru přirozenou volbou, protože podporuje práci s entitami, vazbami i integritou. Teorie databází nabízí nástroje jako normalizace, cizí klíče a transakce, které zajišťují, že data zůstanou konzistentní. Pro systém, kde každá položka představuje finanční hodnotu, je konzistence zásadní.

Na úrovni aplikace se často využívá koncept ORM (object-relational mapping), který překrývá relační data do objektového modelu. ORM zjednodušuje práci s databází, protože vývojář pracuje s entitami a kontextem namísto přímých SQL dotazů. To neznamená, že SQL zcela mizí, ale jeho generování je automatizované a konzistentní. Zároveň je možné kontrolovat, kdy a jak se data ukládají, a přidat validace.

V Invenire je dále využit vzor CQRS (Command Query Responsibility Segregation). Tento přístup rozděluje část systému, která mění stav (commands), a část, která pouze čte data (queries). Teoretická výhoda spočívá v jasně definovaných rozhraních, ve snadnější validaci vstupů a v možnosti optimalizovat čtecí operace nezávisle na zápisu. Pro správu majetku to znamená, že například přidání nové položky je zcela odděleno od dotazu na přehled všech položek, což zvyšuje přehlednost a testovatelnost.

Nezanedbatelným teoretickým východiskem je také práce s dlouhodobými procesy, které v běžném webovém requestu neběží. Příkladem je čištění neověřených účtů, expirovaných pozvánek nebo zamítnutých návrhů změn. Takové úlohy jsou vhodné pro background služby, které periodicky provádějí kontrolu a údržbu dat. Tento mechanismus podporuje čistotu databáze a zajišťuje, že systém nezůstává zahlcen neaktuálními záznamy.

Z teoretického hlediska je důležitá i validace. Vstupy od uživatelů jsou vždy potenciálně chybné nebo neúplné a systém musí umět tyto situace odhalit. Validace na více úrovních (UI, API) vytváří robustní bariéru proti neplatným datům. Výsledkem je větší důvěra v evidenci a méně chyb při inventuře.

### 1.3 Použité technologie a nástroje

Aplikace Invenire je postavena na ekosystému .NET, konkrétně na ASP.NET Core. ASP.NET Core je určeno pro tvorbu webových aplikací a služeb, které mají být rychlé, bezpečné, multiplatformní a vhodné i pro cloudové nasazení. (learn.microsoft.com) Tento rámec poskytuje stabilní základ pro REST API, podporu middleware, autentizace i rozsáhlé nástroje pro konfiguraci a logování. Pro projekt Invenire je výhodné, že se jedná o moderní technologii s dlouhodobou podporou a širokou komunitou.

Frontend aplikace je realizován v Blazor WebAssembly. Blazor je framework pro tvorbu webových UI komponent a může běžet buď na serveru, nebo přímo v prohlížeči na runtime založeném na WebAssembly. (learn.microsoft.com) To znamená, že UI logika běží na straně klienta, ale stále se vyvíjí v jazyce C#, což sjednocuje technologický stack. V Invenire to umožňuje sdílet jazyk a část konceptů mezi backendem i frontendem, což snižuje složitost vývoje.

Pro práci s databází je využit Entity Framework Core. EF Core je lehký, rozšiřitelný, open‑source a multiplatformní ORM, který umožňuje pracovat s databází prostřednictvím .NET objektů a redukuje množství nízkoúrovňového databázového kódu. (learn.microsoft.com) V praxi to znamená, že datové entity jako Admin, Employee nebo Property jsou mapovány na tabulky a databázové operace jsou řízeny kontextem. EF Core zároveň podporuje migrace, což zjednodušuje vývoj a nasazení.

Databázový engine je PostgreSQL. PostgreSQL je výkonný open‑source objektově‑relační databázový systém, který používá a rozšiřuje SQL. (postgresql.org) Výběr PostgreSQL je vhodný zejména kvůli spolehlivosti, bohatému ekosystému a možnosti práce s komplexními datovými typy. V projektu se PostgreSQL používá pro persistentní ukládání všech entit, včetně uživatelů, majetku, inventur a návrhů změn.

Pro lokální vývoj a jednoduché spuštění celého systému je využit Docker. Docker je otevřená platforma pro vývoj, distribuci a běh aplikací a umožňuje balit aplikace do izolovaných, lehkých kontejnerů. (docs.docker.com) Díky tomu lze v rámci Invenire snadno spustit backend i databázi bez složitého nastavování, což je výhodné jak pro vývojáře, tak pro testování. Docker Compose navíc umožňuje definovat více služeb a jejich propojení v jednom souboru.

Kromě hlavních technologií používá projekt i řadu podpůrných knihoven. MediatR podporuje CQRS a zpracování příkazů a dotazů. FluentValidation zajišťuje jednotnou validaci na úrovni aplikace. Serilog slouží pro strukturované logování a umožňuje zapisovat logy do konzole, souboru i externích služeb. V oblasti e‑mailů je použit RazorLight a SMTP klient, které zajišťují generování a odesílání ověřovacích či obnovovacích zpráv.

Specifickým prvkem projektu je generování QR kódů. V backendu se používá QRCoder spolu s ImageSharp pro tvorbu PNG obrázků a přidání textových popisků. Ve frontendu je pak integrován skener pomocí ZXing, což umožňuje přímo v prohlížeči číst QR kódy z kamery zařízení. Tím se propojuje digitální evidence s fyzickým světem majetku.

## 2. Praktická část

### 2.1 O aplikaci

Invenire je webová aplikace navržená pro správu majetku organizace, její zaměstnance a inventarizační procesy. Je koncipována jako modulární systém, který propojuje evidenci majetku s uživatelskými rolemi a umožňuje správci (adminovi) řídit všechny klíčové procesy od založení organizace až po archivaci inventur. Zaměstnanci mají přístup ke konkrétním položkám, které spravují, a aktivně se podílejí na inventurách pomocí skenování QR kódů.

Aplikace pracuje s dvěma hlavními rolemi. Administrátor je vlastníkem organizace a zodpovídá za vedení evidence. V systému zakládá organizaci, zve zaměstnance, vytváří majetek a nastavuje pravidla jeho správy. Zaměstnanec je uživatel, který se do organizace připojuje na základě pozvánky a může pracovat s položkami, které mu byly přiděleny, případně s inventurami, které organizace provádí.

Základní entitou systému je organizace. Organizace představuje kontejner, který sdružuje správce, zaměstnance a majetek. Každá organizace má jednoho správce a může mít více zaměstnanců. Správce je odpovědný za to, že data organizace jsou kompletní a aktuální. Zaměstnanci jsou pak přiřazováni k majetku a mohou navrhovat změny nebo potvrzovat inventury.

Dalším klíčovým prvkem je majetek. V Invenire je majetek definován jako celek, který obsahuje položky. Každá položka je konkrétní fyzická věc s identifikátory (inventární a registrační číslo), názvem, cenou, daty nákupu a prodeje, umístěním a dalšími doplňujícími údaji. Důležitou součástí modelu je i možnost přiřazení položky konkrétnímu zaměstnanci, čímž se zajišťuje odpovědnost.

S majetkem úzce souvisí návrhy změn (suggestions). Zaměstnanci mohou podávat návrhy na úpravu položek – například když zjistí, že se změnilo umístění nebo stav majetku. Administrátor má možnost tyto návrhy schválit, zamítnout nebo upravit. Tím je zajištěna kontrola a zároveň zapojení zaměstnanců do aktualizace dat.

Inventarizace je samostatný proces, který umožňuje ověřit aktuální stav majetku. Administrátor může inventuru založit, pojmenovat a definovat její popis. Inventura má stav „probíhá“ nebo „dokončeno“ a obsahuje seznam položek, které mají být zkontrolovány. Zaměstnanci pak skenují QR kódy položek, čímž se systémově zaznamená, že položka byla ověřena. Po dokončení inventury se stav uzavře a data se archivují, což umožňuje zpětné vyhodnocení.

Z hlediska použitelnosti je aplikace postavena na dashboardu, který se liší podle role. Administrátor vidí sekce pro správu organizace, majetku, návrhů a inventur. Zaměstnanec má přehled o své organizaci a o majetku, který mu byl přiřazen, případně o aktivních inventurách. Tento rozdílný pohled zajišťuje, že každý uživatel pracuje pouze s relevantními funkcemi a není zahlcen zbytečnými informacemi.

### 2.2 Spuštění aplikace

Celé lokální prostředí je postavené na Dockeru a Docker Compose. Docker slouží k zapouzdření backendu, databáze i frontendu do kontejnerů, čímž zajišťuje konzistentní běhové prostředí napříč vývojářskými stroji bez závislosti na lokálně nainstalovaných verzích runtime nebo databází. Docker Compose pak funguje jako orchestrace těchto kontejnerů – definuje jejich služby, porty, proměnné prostředí a vzájemné vazby. Praktické spuštění je stejné pro obě části: v příslušném adresáři stačí spustit docker compose -f docker-compose.dev.yml up --build. Kontejnery backendu i frontendu pak běží odděleně a aplikace je dostupná přes lokální adresy (http://127.0.0.1:... nebo http://localhost:...).

Backend se spouští v adresáři backend a jeho compose konfigurace definuje dvě služby: api (aplikační server) a postgres (databázový server). Síťová a běhová konfigurace backendu je řízena několika navazujícími vrstvami. Na úrovni Dockeru se používají proměnné prostředí, zejména API_PORT (výchozí hodnota 5071), na kterém je vystaveno API, a POSTGRES_HOST_PORT (výchozí hodnota 5433), na který je z kontejneru mapován interní port PostgreSQL 5432. Aplikační konfigurace backendu je dále definována v souborech .env (kopie z .env.example) a appsettings.json, případně appsettings.Development.json, kde jsou soustředěna klíčová nastavení, konkrétně:

připojení k databázi přes ConnectionStrings__Connection,

nastavení JWT autentizace,

SMTP parametry pro odesílání e-mailů,

CORS konfigurace a další aplikační volby.

Důležitá je CORS konfigurace backendu. Povolené originy jsou spravované přes pole CORS:AllowedOrigins (výchozí hodnoty http://127.0.0.1:5170 a http://localhost:5170). Vedle toho se používá i Frontend:BaseAddress, která slouží zejména pro generování odkazů pro emaily (např. ověření účtu nebo obnova hesla). Při přesunu frontendu na jinou doménu nebo port je proto potřeba upravit obě tyto části konfigurace.

Frontend se spouští v adresáři frontend, kde compose služba blazor-client vystavuje Blazor WebAssembly aplikaci na portu 5170. Na rozdíl od backendu frontend nepoužívá .env; endpoint API se nastavuje v klientské konfiguraci, appsettings.json případně appsettings.Development.json, přes ApiConfiguration:BaseAddress, která je ve vývoji standardně http://127.0.0.1:5071/. Díky tomu klient komunikuje s backendem přímo.

### 2.3 Manuál aplikace

Manuál aplikace popisuje běžné uživatelské scénáře tak, jak je reálně používají správci i zaměstnanci. Cílem je ukázat, že Invenire není pouze teoretický systém, ale praktický nástroj, který lze zapojit do každodenního provozu. Následující podkapitoly proto vycházejí z konkrétního UI a reálného chování aplikace.

#### 2.3.1 Správa uživatele

Prvním krokem je registrace uživatele. Na stránce registrace si uživatel volí roli – buď administrátor, nebo zaměstnanec. Tato volba určuje, jaké funkce bude mít k dispozici po přihlášení. Registrace vyžaduje základní údaje, zejména jméno, e‑mail a heslo. Heslo je na backendu hashováno, což zajišťuje bezpečné uložení bez ukládání plaintextu do databáze.

Po registraci probíhá ověření e‑mailu. Backend generuje ověřovací odkaz a odesílá jej na zadanou adresu. Uživatel tak musí potvrdit, že má nad e‑mailem kontrolu. Dokud není ověření dokončeno, nemůže uživatel vykonávat všechny akce – systém rozlišuje ověřené a neověřené role. To je důležité zejména u administrátorů, kteří mají přístup k citlivým operacím.

Přihlášení je realizováno přes formulář, kde uživatel opět volí roli a zadává své přihlašovací údaje. Backend ověřuje kombinaci e‑mailu a hesla a vrací JWT token. Ve frontendu je token uložen a používán při dalších požadavcích. Vzhledem k implementaci CookieHandler se při absenci explicitního Authorization headeru automaticky posílají i cookies, což zjednodušuje práci s ověřením.

Uživatel může také obnovit zapomenuté heslo. V aplikaci je samostatná stránka pro zaslání obnovovacího odkazu. Uživatel zvolí roli, zadá e‑mail a odešle požadavek. Pokud e‑mail existuje, server vytvoří dočasný token a pošle odkaz. Po kliknutí na odkaz je možné nastavit nové heslo.

Uživatel má v aplikaci možnost měnit svoje osobní údaje, pokud by bylo nutno něco změnit.

Správa uživatele zahrnuje i možnost odhlášení. V dashboardu je tlačítko „Odhlásit se“, které vyvolá API požadavek na logout a zároveň vymaže lokální úložiště. To zajišťuje, že na sdíleném zařízení nezůstává aktivní relace.

#### 2.3.2 Správa organizace

Správa organizace je dostupná pouze administrátorům. Po přihlášení, pokud administrátor ještě nemá organizaci, je vyzván k jejímu vytvoření. Formulář pro založení organizace obsahuje název a další základní údaje. Vytvořením organizace se odemknou další části systému, zejména správa majetku a zaměstnanců.

Administrátor může název organizace později upravit. Tato funkce je dostupná v sekci „Základní informace“. Změny jsou ukládány přes API a okamžitě se projeví v UI. Tím je zajištěno, že organizace může reagovat například na změny názvu instituce nebo na jiné administrativní úpravy.

Klíčovou součástí správy organizace je správa zaměstnanců. Administrátor může vytvářet pozvánky pro nové zaměstnance zadáním jejich e‑mailové adresy a případného doprovodného textu. Pozvánka je odeslána zaměstnanci a ten ji může přijmout v aplikaci. Tím se vytvoří vazba mezi zaměstnancem a organizací.

Pozvánky mají omezenou životnost, aby nedocházelo k nekontrolovanému připojování po dlouhé době. Pokud zaměstnanec pozvánku nepřijme do určité doby, server jí smaže. Po přijetí pozvánky je zaměstnanec plnohodnotným členem organizace a může přistupovat k majetku a inventurám.

Správa zaměstnanců zahrnuje i možnost jejich odebrání. Administrátor může zaměstnance z organizace odpojit, což znamená, že daný zaměstnanec přestane mít přístup k majetku. Tento krok je důležitý například při ukončení pracovního poměru. V systému je tento proces řešen bezpečně, aby nedošlo k nekonzistenci dat – majetek zůstává v organizaci, pouze se ruší vazba na konkrétního zaměstnance.

Celá správa organizace tak vytváří jasné zázemí pro další moduly. Bez organizace nelze spravovat majetek, protože organizace je nadřazeným kontejnerem. Tím je zajištěno, že data jsou vždy přiřazena ke konkrétnímu subjektu a že každý uživatel pracuje v rámci jediné organizace.

#### 2.3.3 Správa majetku

Správa majetku je nejrozsáhlejší částí aplikace a kombinuje evidenci, import, export, generování kódů i práci s návrhy změn. V Invenire je nejprve nutné vytvořit majetek jako celek. Administrátor je v dashboardu upozorněn, pokud majetek neexistuje, a může jej založit. Tím se aktivují všechny funkce práce s položkami.

Položky majetku lze zadávat více způsoby. Základní možností je manuální správa, kde administrátor upravuje položky přímo v rozhraní, doplňuje údaje a přiřazuje je zaměstnancům. Každá položka má identifikátory (inventární a registrační číslo), název, cenu, seriové číslo, datum nákupu a případného prodeje, umístění (budova, místnost, poznámka), popis a číslo dokladu. Tato struktura umožňuje detailní evidenci a zároveň odpovídá požadavkům běžné praxe.

Pro rychlé zavedení většího množství položek je k dispozici import. Aplikace podporuje import z JSON i z Excelu (XLSX). Import z JSON je určen pro případy, kdy organizace již má data v jiném systému a dokáže je exportovat. Import z Excelu je naopak praktičtější pro běžné uživatele; systém nejprve načte záhlaví tabulky a uživateli umožní mapovat sloupce na jednotlivé atributy položky. Tím se minimalizuje riziko špatného přiřazení dat.

Po importu lze data exportovat zpět do JSON nebo XLSX. Export je užitečný pro archivaci, sdílení dat s externími subjekty nebo pro zálohování. V praxi to znamená, že správce může kdykoliv získat aktuální snapshot evidence majetku ve standardizovaném formátu.

Administrátor má v přehledu položek k dispozici filtraci a hromadné operace. Může filtrovat podle ceny, data nákupu, data přidání, budovy, místnosti nebo podle toho, zda již položka má vygenerovaný QR kód. Dále může vyhledávat podle textu a řadit výsledky. To je praktické zejména při práci s velkým množstvím položek.

Součástí správy majetku je i generování QR kódů. Administrátor může vybrat sadu položek a systém vygeneruje QR kódy v požadované velikosti. Výsledkem je ZIP soubor, který lze stáhnout a dále zpracovat (např. vytisknout). QR kódy obsahují odkaz na endpoint pro skenování konkrétní položky, takže při inventuře stačí kód naskenovat a systém okamžitě ví, o jakou položku se jedná.

Správa majetku zahrnuje také návrhy změn. Zaměstnanci mohou vytvořit návrh na úpravu položky – například změnu umístění nebo opravu názvu. Administrátor návrh vidí v přehledu, může jej schválit, zamítnout nebo upravit. Tím se podporuje spolupráce a zároveň kontrola. Návrhy mají životnost, po jejímž uplynutí jsou automaticky odstraněny, aby se evidence nezahlt́ila starými záznamy.

#### 2.3.4 Správa inventarizace

Inventarizace je proces, který ověřuje reálný stav majetku a porovnává jej s evidencí. Administrátor může inventuru založit zadáním názvu a popisu. Tím se vytvoří záznam o nové inventuře a systém ji označí jako „probíhající“. V této fázi mohou zaměstnanci začít skenovat položky.

Skenování probíhá přímo v aplikaci pomocí kamery. Frontend využívá integrovaný skener, který čte QR kód a ověřuje, zda odpovídá očekávanému formátu. Pokud je kód validní, aplikace odešle požadavek na backend, který zaznamená, že položka byla naskenována. To je rychlé a minimalizuje riziko chyb, protože identifikátor položky je jednoznačný.

Inventura má vlastní stav a časové údaje. Po dokončení inventury administrátor provede uzavření, které změní stav na „dokončeno“ a uloží čas ukončení. Tím je vytvořena auditní stopa, která umožňuje zpětné vyhodnocení. Správce může například ověřit, kdy byla inventura provedena, a porovnat, kolik položek bylo skutečně nalezeno.

Výhodou tohoto přístupu je, že inventura není jednorázovým ručním procesem, ale systematickou funkcí systému. Výsledky jsou ukládány do databáze, což umožňuje navazující statistiky i kontrolu. Organizace tak může snadno doložit, kdy byla inventura provedena a které položky byly ověřeny.

Inventarizace v Invenire také propojuje administrátora a zaměstnance. Administrátor inventuru zakládá a uzavírá, zaměstnanci jsou ti, kteří ji realizují v terénu. Tento model odpovídá reálnému pracovnímu rozdělení a podporuje odpovědnost: každý zaměstnanec ví, které položky má ověřit, a administrátor má přehled o výsledcích.

V praktickém nasazení lze inventuru provádět periodicky (např. jednou ročně) nebo podle potřeby (např. při změně organizace). Systém umožňuje snadné založení nové inventury a nevyžaduje složité nastavování. Tím se inventura stává přirozenou součástí správy majetku, nikoli mimořádnou administrativní zátěží.

### 2.4 Vývoj aplikace

Vývoj Invenire probíhal postupně v navazujících vlnách. Nešlo o jednorázové „postavení všeho naráz“, ale o evoluční proces, kdy se nejdříve vytvořil základ infrastruktury a bezpečnosti, poté se rozšiřovaly doménové funkce (organizace, majetek, inventury) a nakonec se posilovalo UX, import/export i testování. Tento přístup zajišťoval, že každá nová část měla stabilní základ a mohla být průběžně ověřována.

Na backendu byl jako první krok vybudován technický základ – logování, JWT autentizace a testovací prostředí. Následně přišly employee endpointy a e‑mailová verifikace, aby systém vůbec mohl řídit přístup. Po vyřešení ověřování se přidaly admin endpointy a organizace, protože bez nich nemá smysl spravovat majetek. Další fáze rozšířila systém o CQRS strukturu, validace a jednotné repository rozhraní. Poté se přešlo na majetek, položky a inventury, včetně skenování a QR kódů. V poslední fázi se doplnil export/import, rozšířená filtrace, aktivní inventury a postupně přibývaly testy a dokumentace.

Frontend začal jednoduše: registrace, login, základní layout a práce s cookies. Jakmile byly hotové backendové endpoints, přidal se dashboard a správa organizace, poté správa položek a masové operace (hromadné změny, mazání). Následně přibyly návrhy změn, inventury a QR kódy, a později import/export a pokročilé filtrování. Paralelně se vyvíjelo UX (modal okna, validace, přehledové karty) a nakonec se doplnila obnova hesla a parametr pro velikost QR kódů.

Tento vývoj v čase se promítl do finální architektury: backend má jasně oddělené vrstvy, frontend stabilní komponentní strukturu a oba se postupně rozšiřovaly tak, aby vždy bylo možné aplikaci používat a testovat.

#### 2.4.1 Backend

**Fáze 1 – infrastruktura, autentizace, logování**  
Backend začal vytvořením základního REST API, JWT autentizace a logování. Bezpečnost byla klíčová už od startu, protože aplikace pracuje s citlivými daty organizací. Součástí této fáze bylo i nastavení Serilogu a testovacího prostředí, aby bylo možné průběžně ověřovat správnou funkčnost.  
V této etapě se rozhodovalo o směrování endpointů, základním middleware pořadí a způsobu práce s chybami tak, aby výstupy API měly jednotný tvar. Důraz byl i na to, aby šlo systém spustit lokálně bez složité konfigurace, což usnadnilo další iterace. Zároveň se nastavily limity pro nahrávání souborů a základní CORS pravidla.

**Ukázka – konfigurace aplikace (Program.cs)**

```csharp
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureCors(builder.Configuration);
builder.Services.ConfigureHashing();
builder.Services.ConfigureMediatR();
builder.Services.ConfigureRareLimiters();
builder.Services.ConfigureEmailService(builder.Configuration);
builder.Services.ConfigureErrorHandling();
builder.Services.ConfigureDatabaseContext(builder.Configuration.GetConnectionString("DevelopmentConnection")!);

builder.Services.AddScoped<IJwtManager, JwtManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IQuickResponseCodeGenerator, QuickResponseCodeGenerator>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
```

**Fáze 2 – zaměstnanci a administrátoři**  
Po technickém základu se přidal lifecycle uživatelů: registrace, login, ověření e‑mailu, reset hesla. Zásadní byla migrace validací do FluentValidation a zavedení CQRS přes MediatR. V této fázi vznikly i background služby pro automatické čištění neověřených účtů.  
Současně se ladily modely pro Admin a Employee, aby reflektovaly reálné potřeby (oddělené jméno/příjmení, stavy ověření, časové značky). Bylo třeba vyřešit, jakým způsobem se budou tokeny předávat a ukládat, aby šlo bezpečně používat cookie i Authorization header. Výsledkem byla stabilní základna, na které se daly stavět organizační funkce.

**Ukázka – JWT konfigurace a politiky**

```csharp
services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = options.Issuer,
            ValidAudience = options.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
        };
    });

services.AddAuthorizationBuilder()
    .AddPolicy(Jwt.Policies.ADMIN, policy =>
    {
        policy.RequireRole(Jwt.Roles.ADMIN);
        policy.RequireClaim("is_verified", bool.TrueString);
    });
```

**Fáze 3 – organizace a pozvánky**  
Jakmile existovali ověřitelní uživatelé, vznikla logika organizací, pozvánek a správy zaměstnanců. Byla doplněna integrace s e‑mailovým systémem a pozvánky dostaly životní cyklus včetně expirace a cleanup služeb.  
V této fázi se stabilizoval datový model organizace a vazby mezi adminem, zaměstnanci a pozvánkami. Důležitá byla také pravidla pro vstup do organizace, aby nebylo možné obejít kontrolu a připojit se bez platné pozvánky. Backend se rozšířil o query endpointy pro přehled organizace a postupně se začaly řešit okrajové stavy, například mazání zaměstnance nebo opětovné pozvání.

**Ukázka – část entity Organization**

```csharp
public required Guid Id { get; set; }
public required string Name { get; set; }
public required DateTimeOffset CreatedAt { get; set; }
public required DateTimeOffset? LastUpdatedAt { get; set; }

public Admin? Admin { get; set; }
public Property? Property { get; private set; }
public ICollection<Employee> Employees { get; } = [];
public ICollection<OrganizationInvitation> Invitations { get; } = [];
```

**Fáze 4 – majetek, položky, inventury**  
Další fáze přinesla nejsilnější rozšíření: property, property items, návrhy změn a inventury. Implementovalo se skenování, generování QR kódů a export/import dat. Postupně se rozšiřovaly query endpoints o filtrování, řazení a statistiky.  
Z hlediska vývoje šlo o největší objem práce: bylo potřeba definovat detailní strukturu položek, přidat validace, řešit přiřazování zaměstnancům a doplnit inventurní logiku. Významným krokem bylo zavedení QR kódů a archivace skenů, což vyžadovalo konzistentní uložení stavu a časových značek. Zároveň se ladilo výkonové chování filtrů tak, aby i větší objemy položek zůstaly použitelné.

**Ukázka – endpoint pro sken položky**

```csharp
[Authorize()]
[HttpPut("/api/properties/items/{itemId:guid}/scan")]
public async Task<IActionResult> ScanItem(Guid itemId)
{
    await _mediator.Send(new ScanPropertyItemCommand
    {
        Jwt = JwtBuilder.Parse(HttpContext.Request.ParseJwtToken()),
        ItemId = itemId,
    });

    return NoContent();
}
```

**Ukázka – generování QR kódu s popisky**

```csharp
public byte[] GenerateCodeWithLabels(string content, IReadOnlyList<string> labels, int size = MinSize)
{
    if (size < MinSize || size > MaxSize)
    {
        throw new ArgumentException($"Size must be between {MinSize} and {MaxSize}. Received: {size}.");
    }

    var labelSpace = labels.Count != 0 ? (int)(size * TextFraction) : 0;
    var qrSpace = size - labelSpace;

    var qrImage = LoadQr(content);
    var scale = Math.Min((float)qrSpace / qrImage.Width, (float)qrSpace / qrImage.Height);

    using var canvas = new Image<Rgba32>(size, size);
    canvas.Mutate(ctx =>
    {
        ctx.Fill(Color.White);
        DrawQr(ctx, qrImage, size, qrSpace, scale);
        if (labels.Count != 0) DrawLabels(ctx, [.. labels], size, qrSpace, labelSpace);
    });

    return ToPng(canvas);
}
```

**Fáze 5 – rozšíření API, export/import, testy a dokumentace**  
Po stabilizaci hlavních funkcí se rozšířily exporty (JSON/XLSX), zlepšilo se filtrování, přibyly aktivní inventury a hlavně se intenzivně pokrývaly testy (unit i integrace). Dokumentace postupně doplnila každou vrstvu.  
V této fázi se řešila spolehlivost a dlouhodobá udržitelnost: přibývaly testy pro kritické scénáře, doplnily se okrajové případy a vyladily se chyby z praxe. Dokumentace a README byly rozšířeny tak, aby nový vývojář nebo uživatel dokázal systém rychle spustit a pochopit. Dořešily se i drobné technické detaily, jako jsou konzistentní odpovědi na validace a lepší práce s chybami.

#### 2.4.2 Frontend

**Fáze 1 – základní UI a autentizace**  
Frontend začal jednoduchými stránkami pro registraci a přihlášení. Poté se přidalo ukládání cookies a ověřovací obrazovky, aby bylo možné dokončit e‑mail verification flow.  
Na začátku šlo hlavně o to, aby uživatelé mohli projít základním vstupem do systému a aby UI poskytovalo jasnou volbu rolí. V této fázi se definoval základní layout, formát hlášení chyb a první sada validací na straně klienta. Tím vznikl stabilní základ pro další rozšiřování.

**Ukázka – login stránka (výřez)**

```razor
<div class="surface-card">
    <label>Vyberte typ přihlášení</label>
    <select @bind="Role">
        <option value="Employee">Zaměstnanec</option>
        <option value="Admin">Admin</option>
    </select>
</div>

<div class="form-stack">
    @if (Role == "Employee")
    {
        <LoginEmployeeForm />
    }
    else if (Role == "Admin")
    {
        <LoginAdminForm />
    }
</div>
```

**Fáze 2 – dashboard a organizace**  
Po ověření přístupu vznikl admin dashboard se základním přehledem organizace, zaměstnanců a pozvánek. Paralelně se vyvíjel zaměstnanecký dashboard.  
Zde bylo důležité sjednotit práci s API a rozhodnout, co se má zobrazit podle role. Přibyla také persistace vybraných dat do LocalStorage pro lepší UX a rychlejší načítání. Dashboardy se postupně rozšiřovaly o podrobnější přehledy a začaly definovat vizuální styl celé aplikace.

**Ukázka – dashboard rozhodování podle role**

```razor
@if (Role == JwtRole.Admin)
{
    if (MissingOrganization is true)
    {
        <CreateOrganizationForm OnSuccessfulCreation="() => { MissingOrganization = false; StateHasChanged(); }" />
    }
    else
    {
        <AdminOrganizationOverview />
        <AdminPropertyOverview />
    }
}
else if (Role == JwtRole.Employee)
{
    if (MissingOrganization is true)
    {
        <EmployeeOrganizationInvitationOverview OnSuccessfulJoin="() => { MissingOrganization = false; StateHasChanged(); }" />
    }
    else
    {
        <EmployeeOrganizationOverview />
        <EmployeePropertyOverview />
    }
}
```

**Fáze 3 – majetek, položky, hromadné změny**  
Další vlna byla zaměřena na správu majetku a položek, včetně pokročilého filtrování, hromadných změn a importů. UI přidalo modální okna, action řádky a error panely.  
V této etapě se ladila práce s většími datovými sadami a přehlednost editace. Bylo potřeba vyřešit hromadné operace tak, aby uživatel jasně viděl, co se bude měnit a co je jen označené k odstranění. UX se doplnilo o potvrzovací kroky a systém zobrazení chyb, aby se minimalizovaly omyly při správě majetku.

**Ukázka – import z Excelu (výřez)**

```razor
@if (Headers.Count == 0)
{
    <p class="modal-description">Prosím, vyberte Excel soubor, aby bylo možné načíst záhlaví tabulky.</p>
    <button class="btn-secondary" type="button" @onclick="async () => { await OpenXlsx(); }">Vybrat XLSX soubor</button>
}
else
{
    <p class="modal-description">Přiřaďte odpovídající záhlaví ke každé položce označené hvězdičkou.</p>

    @foreach (var property in Columns.Keys.ToList())
    {
        <div class="form-group">
            <label>@Translate(property):</label>
            <select @bind="Columns[property]">
                <option value="">(nepřiřazeno)</option>
                @foreach (var header in Headers)
                {
                    <option value="@header.Letter">@header.Name (@header.Letter)</option>
                }
            </select>
        </div>
    }
}
```

**Fáze 4 – inventury, QR kódy, skenování**  
Frontend dostal podporu pro inventury, aktivní skenování a stahování QR kódů. Ve frontendu tak vznikl nejen přehled inventur, ale i praktický skener pro zaměstnance.  
Tato fáze vyžadovala propojení UI s hardwarem zařízení, což přineslo nové okrajové stavy (např. čekání na kameru, výběr zařízení). Zároveň se ladilo, aby skenování bylo rychlé a nezatěžovalo uživatele zbytečnými kroky. Díky tomu se inventury staly použitelnou funkcí i mimo kancelářské prostředí.

**Ukázka – QR skenování v Blazoru**

```razor
<BarcodeReader
    OnBarcodeReceived="Scan"
    StartCameraAutomatically="true"
    ShowStart="false"
    ShowReset="false"
    ShowResult="false"
    ShowStop="false"
    ShowToggleTorch="false"
    ShowVideoDeviceList="true"
    Title=""
    LabelVideoDeviceListText="Změnit kameru: "
    TextWithoutDevices="Probíhá načítání kamery..."
/>
```

**Fáze 5 – exporty, obnova hesla, UX refinements**  
V závěru přibyly exporty (JSON/XLSX), obnova hesla a drobné UI úpravy. Zároveň se doplnila možnost nastavovat velikost QR kódů, aby systém byl flexibilnější při tisku.  
Kromě funkčního doplnění se řešily i drobné UX detaily, které zvyšují profesionalitu aplikace: konzistentní textace, sjednocené komponenty formulářů a plynulé přechody mezi kroky. Tato fáze také zohlednila reálné použití, kdy uživatelé potřebují data exportovat nebo řešit ztrátu přístupu bez zásahu administrátora.

**Ukázka – export do souboru (výřez)**

```razor
var response = await Client.GetAsync("/api/properties/items/export/excel");

if (response.StatusCode != HttpStatusCode.OK)
{
    var error = await response.Content.ReadFromJsonAsync<ErrorResponse>() ?? throw new NullReferenceException();
    Error = ErrorTranslator.Translate(error.Detail, ExportToExcelPropertyItemResponse.ErrorTranslations);
    return;
}

var bytes = await response.Content.ReadAsByteArrayAsync();
await JS.InvokeVoidAsync("download_file", $"export-{DateTime.Now:yyyyMMdd}.xlsx", "application/zip", bytes);
```

### 2.5 Bezpečnost

Bezpečnost je v Invenire řešena na několika úrovních. Základ tvoří JWT autentizace. Token obsahuje identitu uživatele, jeho roli a stav ověření, což umožňuje serveru jednoznačně rozhodnout o přístupu. Token je přenášen buď v Authorization headeru, nebo v cookie, což zvyšuje flexibilitu klienta.

Dalším prvkem je autorizace pomocí politik. Admin může provádět operace jako vytváření organizace, správa majetku nebo uzavírání inventur. Zaměstnanec má přístup pouze ke svým položkám a k inventurám. Kromě role se kontroluje i ověření e‑mailu, takže neověřené účty nemohou provádět citlivé akce. Tento model chrání systém před neoprávněnými zásahy.

Bezpečnost se týká i práce s hesly. Hesla nejsou ukládána v databázi v otevřené podobě, ale jsou hashována pomocí standardního hasheru. To znamená, že i v případě úniku databáze není možné přímo přečíst hesla uživatelů. Zároveň je při registraci i obnově hesla vyžadována minimální délka, což snižuje riziko slabých hesel.

Dalším důležitým mechanismem je rate limiting. Přihlašování je omezeno na určitý počet pokusů v definovaném čase, stejně jako odesílání ověřovacích e‑mailů. Tyto limity chrání systém před útoky hrubou silou a před zneužitím e‑mailových funkcí. Pro běžného uživatele je tento mechanismus transparentní, ale významně zvyšuje bezpečnost systému.

CORS politika zajišťuje, že API přijímá požadavky pouze z definované frontend adresy. To snižuje riziko, že API bude zneužito z neautorizovaných domén. V případě změny frontendu stačí upravit konfigurační hodnotu, což poskytuje flexibilitu bez narušení bezpečnostních pravidel.

Validace vstupů je implementována na více úrovních. Frontend používá validační komponenty, které uživatele upozorní na chyby ještě před odesláním. Backend následně provádí další kontrolu pomocí FluentValidation. Díky tomu se do databáze nedostanou neplatná data a riziko nekonzistence se minimalizuje. Součástí bezpečnosti je i centralizovaný exception handler, který vrací standardizované chyby a neodhaluje interní detaily serveru.

Bezpečnost podporují také background služby, které odstraňují neověřené účty a expirované záznamy. Tento mechanismus snižuje riziko, že staré účty budou zneužity nebo že databáze bude obsahovat neaktuální údaje. V konečném důsledku se tak zvyšuje důvěryhodnost celého systému.

### 2.6 Testování

Testování je v Invenire zaměřeno především na backendovou logiku a API. Projekt obsahuje integrační testy, které ověřují, že klíčové endpointy fungují správně. Například testy serverových endpointů kontrolují, že health check vrací správný stav a že ověření role funguje podle očekávání. Tyto testy používají testovací server a simulují reálné HTTP požadavky.

Součástí testování jsou i unit testy vybraných handlerů a validačních logik. Pro testy se používají fakers, které generují realistická testovací data (například pro adminy nebo zaměstnance). Tím je možné ověřit, že systém reaguje správně na validní i nevalidní vstupy. Testy tak přispívají k důvěře ve správné fungování systému a snižují riziko regresí při budoucích změnách.

Frontend není v aktuální implementaci pokryt automatickými testy, ale je testován manuálně. V praxi to znamená ověřování registrace, přihlášení, správy majetku a inventur přímo v UI. Tento přístup je běžný u menších projektů a umožňuje rychlou kontrolu chování. V budoucnu by bylo možné přidat automatizované UI testy, například pomocí Playwright, čímž by se testovací pokrytí dále zlepšilo.

Testovací strategie tak reflektuje reálné potřeby projektu. Backend je kritický pro konzistenci dat a bezpečnost, proto je testován systematicky. Frontend se zatím ověřuje manuálně, což je pro maturitní projekt dostatečné, ale zároveň je zde prostor pro další rozvoj.

### Závěr

V úvodu byl stanoven cíl, navrhnout a realizovat webovou aplikaci, která sjednotí správu majetku, role uživatelů a inventarizaci do jednoho bezpečného a prakticky použitelného systému. Aplikace Invenire vznikla jako funkční řešení, které propojuje evidenci majetku, správu organizace a zaměstnanců, generování QR kódů a inventury do jednoho celku.

Výsledek práce ukazuje, že zvolený technologický stack (.NET 9, Blazor WebAssembly, PostgreSQL) umožňuje vybudovat systém s jasnou architekturou, dobrou bezpečností a přehledným UI. Implementace pokrývá klíčové požadavky: ověřování uživatelů, role‑based přístup, import/export dat a inventarizaci s QR kódy. Tím je dosaženo původního cíle – vytvořit aplikaci, která je použitelná v reálném prostředí a zároveň splňuje technologické a bezpečnostní nároky.

Použité zdroje (výběr): RFC 7519: JSON Web Token (JWT). (rfc-editor.org) Roy T. Fielding: Architectural Styles and the Design of Network-based Software Architectures (REST). (ics.uci.edu) Dokumentace ASP.NET Core. (learn.microsoft.com) Dokumentace Blazor hosting models. (learn.microsoft.com) Dokumentace Entity Framework Core. (learn.microsoft.com) PostgreSQL – About. (postgresql.org) Docker Docs – What is Docker? (docs.docker.com) Swagger UI. (swagger.io)
