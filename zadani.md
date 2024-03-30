
# Stáž 2024 – Skladník Eda
Předtím než nastoupíš do Edhouse, musíš odpracovat zkušební směnu na tzv. *Předůležitém překladišti*. Přece nebudeme do Edhousu brát někoho, kdo nám neukáže, že „za to umí vzít“. Autobus, tě spolu s ostatními stážisty právě vysadil před vraty velké haly překladiště.

„Ach, to je zase den!“ povzdechne si urostlý chlap v ošoupaných monterkách stojící opodál. „Hej ty novej, pocem“ huláká a ukazuje prstem na tebe. “Já su Eda. Potřebuju helfnout.” bručí, zatímco z náprsní kapsy vytahuje aktuální mapku zboží na překladišti.

**Eda potřebuje, abys sečetl čísla aktivních kontejnerů**. Budeš k tomu potřebovat jeho mapku, **kterou najdeš přiloženou k tomuto zadání**. Podívejme se na následující **příklad**:
|   |   |   |   |   |   |   |   |   |   |
|---|---|---|---|---|---|---|---|---|----|
| 4 | 6 | 7 | . | . | 2 | 5 | 7 | . | .  |
| . | . | . | * | . | . | . | . | . | .  |
| . | . | 3 | 5 | . | . | 6 | 3 | 3 | .  |
| . | . | . | . | . | . | # | . | . | .  |
| 6 | 1 | 7 | * | . | . | . | . | . | .  |
| . | . | . | . | . | + | . | 1 | 3 | .  |
| . | . | 5 | 9 | 2 | . | . | . | . | .  |
| . | . | . | . | . | . | 7 | 5 | 5 | .  |
| . | . | . | $ | . | * | . | . | . | .  |
| . | 6 | 6 | 4 | . | 5 | 9 | 8 | . | .  |

Na mapce je vyznačena spousta čísel a symbolů, kterým úplně nerozumíš. To ale nevadí, protože jak Eda prozrazuje, každé číslo, které sousedí s nějakým symbolem, byť diagonálně, je číslo aktivního kontejneru a je nutné ho započítat do výsledné sumy (Tečky (.) nepovažujeme za symbol). Na mapce příkladu jsou dvě čísla, která nejsou čísly aktivního kontejneru, neboť nesousedí s žádným symbolem: 257 (vpravo nahoře) a 13 (vpravo uprostřed). Všechna ostatní čísla sousedí s nějakým symbolem a tudíž se jedná o čísla aktivních kontejnerů; jejich součet je 4361.

## Vstupní data
Edova skutečná mapka je samozřejmě mnohem větší a najdeš ji vloženou v tomto dokumentu a pro jistotu také přiloženou.

(soubor mapka.txt)
**Jaký je součet čísel aktivních kontejnerů na Edově mapce?**

## Pokyny
- Zvolte jazyk a prostředí dle preference – C++ / C# / Java / Python / Rust / JavaScript / TypeScript
- Napište program, který
o načte data ze standardního vstupu (STDIN), viz upřesnění níže
o co nejefektivněji vyřeší výše popsaný úkol
o vypíše odpověď na standardní výstup (STDOUT)
- Na adresu specifikovanou v průvodním e-mailu, nejpozději do data uvedeného tamtéž zašlete e-mail,
obsahující
o V textu emailu – popis Vámi zvoleného prostředí a zejména instrukce k přeložení a spuštění
vašeho programu
o V textu emailu - popis použitého algoritmu
o V textu emailu – vypočtenou hodnotu
o V příloze pak přeložitelný (či interpretovatelný) program ve formě zdrojových kódu a všech
dalších potřebných projektových souborů.

Upřesnění: Chceme, aby bylo možné vaše programy snadno spouštět z příkazové řádky:
`C:\muj_kod> program.exe < priklad.txt`
`4361`
`C:\muj_kod>`

V Pythonu, JS a TS je potřeba něco málo přidat, ale fungovat to bude stejně, např:
`C:\muj_kod> python program.py < priklad.txt`
`4361`
`C:\muj_kod>`
