# Stáž 2024 – Skladník Eda
## Popis
Zadání je splněno v prostředí .NET 7 s pomocí jazyka C#. Vývojovým prostředím bylo Microsoft Visual Studio 2022.
Projekt je sestaven pro OS Windows 10 a vyšší. Pro spuštění NENÍ třeba mít nainstalované rozhraní .NET
## Spuštění
1. Stáhnout *.zip soubor s projektem a extrahovat jej
2. Otevřít příkazový řádek s adresářem ve složce projektu
3. Navigovat do `EdHouse_UkolProStazisty_2024\bin\Release\`
4. Napsat do příkazového řádku `EdHouse_UkolProStazisty_2024.exe < cesta_k_souboru_s_mapou_skladiste.txt`
   1. `cesta_k_souboru_s_mapou_skladiste.txt` nahradit absolutní či relativní cestou k libovolnému souboru obsahující mapu skladiště
   2. Též je možné využít dvou přiložených ukázkových souborů pomocí `"../../Input Data/warehouse map large CRLF.txt"`
5. Zanalyzovat výsledek
## Princip fungování
1. Vytvořit instanci třídy Warehouse
   1. Při volání konstruktoru spočítat velikost skladiště (řádky, sloupce)
2. Najít v instanci všechny kontejnery
   1. Na základě vzoru `\\d{1,}` najít všechny podřetězce, které obsahují jedno nebo více číslic
   2. S pomocí match.Index a velikosti skladiště spočítat souřadnice nejzažšího levého bodu kontejneru
   3. Vytvořit instanci nalezeného kontejneru
3. Najít v instanci všechny symboly
   1. Na základě vzoru `[^.\\d\r\n]` najít všechny podřetězce, které neobsahují tečku, číslici, \r nebo \n
   2. S pomocí match.Index a velikosti skladiště spočítat souřadnice symbolu
   3. Vytvořit instanci souřadnice symbolu
4. Najít kontejnery sousedící se symbolem
   1. Vytvořit prázdný seznam kontejnerů
   2. Spočítat oblast kolem každého kontejneru se vzdáleností 1 od něj z každé strany
   3. Jestli se ve spočítané oblasti kolem kontejneru nachází symbol, přidat jej do vytvořeného seznamu
5. Spočítat součet kontejnerů sousedící se symbolem
   1. Extrahovat ze seznamu instancí kontejnerů sousedících se symboly jejich číslo s pomocí .Select() rozšíření z knihovny LinQ
   2. Spočítat součet instancí kontejnerů sousedících se symboly s pomocí .Sum() rozšíření z knihovny LinQ
## Optimalizace
- Program je napsaný v jazyce C#, který dosahuje větší rychlosti než interpretované jazyky jako např. Python či JavaScript.
- Publikovaná verze (s optimalizacemi kompilátoru) dosahuje zvýšení výkonu programu až o 25 %.
- Regular expression vzor je kompilovaný, čímž se snižuje množství času na provedení kroků 1. až 5. až o 23 %.
- Počítání velikosti skladiště probíhá bez využítí string.Split(). Využití tohoto způsobu by vytvořilo array v paměti velikosti větší než původní vstupní string.
- Ač může být vstupní řetězec opravdu velký, nevytvářejí se jeho kopie, v paměti existuje jen jednou, existují jen reference na něj.
- Projekt je sestaven tak, aby výsledný spustitelný program zahrnoval jen ty zabudované knihovny, které opravdu potřebuje, čímž se velikost složky se spustitelným souborem snižuje o více než 100 MB.
## Výsledek
- Spočtený výsledek pro velkou mapu: **557705**
## Extras
- Při debuggingu se nejen zobrazuje čas, který trvalo hledání výsledku, ale i vizuální výpis kontejnerů do konzole pro lepší představu.
- Zdrojový kód je napsán anglicky a zároveň obsahuje popisky tříd, metod a vlastností.