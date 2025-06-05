Zadání

Cíl

Vytvořte konzolovou aplikaci pro správu knihovny, která umožní:

    Přidávat knihy do knihovny.
    Vypisovat knihy podle různých kritérií.
    Zobrazovat statistiky o knihách.
    Vyhledávat knihy podle autora nebo klíčového slova v názvu.

Zadání

Třída Book

Vytvořte třídu Book, která bude mít následující vlastnosti:

    Title (string) – název knihy
    Author (string) – autor knihy
    PublishedDate (DateTime) – datum vydání
    Pages (int) – počet stran

Použijte veřejné vlastnosti, implementuje vlastní gettery/settery tam, kde se to hodí (např. validace, že počet stran je kladné číslo).
Funkcionalita programu

Program bude opakovaně číst vstup z konzole. Vstup může být jeden z následujících:

    ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]
    Např.: ADD;1984;George Orwell;1949-06-08;328
    LIST
    Vypíše všechny knihy, seřazené podle data vydání. Použijte OrderBy
    STATS
    Vypíše:
        Průměrný počet stran (použijte Select a Average)
        Počet knih od každého autora (použijte GroupBy)
        Počet unikatních slov v názvech knih. Použijte SelectMany a rozdělení názvů podle mezer (interpunkci vynechte) pro vytvoření jednoho seznamu všech slov, pak použijte Distinct.

    FIND;[klíčové slovo]
    Vyhledá knihy, jejichž název obsahuje dané slovo, bez ohledu na velikost písmen (použijte Where).
    END
    Ukončí program.

Příklad vstupu a výstupu

Vstup:

ADD;1984;George Orwell;1949-06-08;328
ADD;Brave New World;Aldous Huxley;1932-01-01;311
ADD;Animal Farm;George Orwell;1945-08-17;112
LIST
STATS
FIND;new
END

Výstup:

Kniha: 1984, autor: George Orwell, vydáno 8.6.1949, stran: 328
Kniha: Animal Farm, autor: George Orwell, vydáno 17.8.1945, stran: 112
Kniha: Brave New World, autor: Aldous Huxley, vydáno 1.1.1932, stran: 311

Statistiky:
Průměrný počet stran: 250
Počet knih podle autora:
 - George Orwell: 2
 - Aldous Huxley: 1

Výsledky hledání pro "new":
 - Brave New World

Požadavky na implementaci

    Použijte List<Book> pro ukládání knih.
    Použijte LINQ (Where, Select, GroupBy, OrderBy, SelectMany  – dle potřeby).
    Pracujte se stringy (Contains, Split – dle potřeby).
    Pracujte s DateTime pro výpis knih.
    Validujte vstup (např. správný formát data, počet stran > 0).
    Program nesmí spadnout na špatně zadaný vstup.
