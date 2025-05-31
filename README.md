# wzorce_projektowe_2


## zadanie 1

+---------------------+
|      Logger         |   
+---------------------+
| - _instance: Logger |
| - _logs: list       |
+---------------------+
| + get_instance()    |
| + log(msg: str)     |
| + get_logs() -> list|
+---------------------+


pseudokod:

class Logger {
    private static Logger instance;
    private List<string> logs;

    private Logger() {
        logs = new List<string>();
    }

    public static Logger Instance {
        get {
            if (instance == null)
                instance = new Logger();
            return instance;
        }
    }

    public void Log(string message) {
        logs.Add(message);
    }

    public List<string> GetLogs() {
        return logs;
    }
}


## zadanie 2




### Opis projektu

Ten projekt ilustruje zastosowanie wzorca **Singleton** do zaimplementowania bufora wydruku (kolejki zadań drukowania). Główne elementy:
- **PrintJob** – klasa reprezentująca pojedyncze zadanie drukowania (identyfikator, nazwa dokumentu, liczba stron).
- **PrintBuffer** – klasa Singleton, zarządzająca kolejką zadań typu PrintJob w modelu FIFO.

Poniżej znajduje się diagram UML przedstawiający strukturę oraz relacje pomiędzy klasami.

---

### UML Diagram

```uml
'----------------------------
' Klasa: PrintJob
'----------------------------
class PrintJob {
    - job_id: int
    - document_name: str
    - pages: int
    + PrintJob(job_id: int, document_name: str, pages: int)
    + __str__(): str
}

'----------------------------
' Klasa: PrintBuffer (Singleton)
'----------------------------
class PrintBuffer {
    - __instance: PrintBuffer [static, private]
    - jobs: List<PrintJob>
    - PrintBuffer() [private]
    + getInstance(): PrintBuffer [static]
    + addJob(job: PrintJob): void
    + getNextJob(): PrintJob
    + processNextJob(): PrintJob
    + listJobs(): List<PrintJob>
}

' Relacja: PrintBuffer zawiera wiele PrintJob (kolekcja)
PrintBuffer "1" -- "*" PrintJob : zarządza >
```



// ---------------------------
// Klasa: PrintJob
// ---------------------------
class PrintJob:
    atrybuty:
        job_id: int
        document_name: string
        pages: int

    konstruktor PrintJob(job_id, document_name, pages):
        this.job_id = job_id
        this.document_name = document_name
        this.pages = pages

    metoda __str__():
        zwróć "PrintJob[id=" + job_id + ", document='" + document_name + "', pages=" + pages + "]"


// ---------------------------
// Klasa: PrintBuffer (Singleton)
// ---------------------------
class PrintBuffer:
    prywatne statyczne:
        instance: PrintBuffer ← NULL

    prywatne:
        jobs: kolejka<PrintJob>

    prywatny konstruktor PrintBuffer():
        jobs ← pusta kolejka

    publiczne statyczne:
        metoda getInstance() → PrintBuffer:
            jeżeli instance == NULL:
                instance ← nowy PrintBuffer()
            zwróć instance

    publiczne:
        metoda addJob(job: PrintJob) → void:
            dołącz job do jobs
            wyświetl "Dodano zadanie: " + job

        metoda getNextJob() → PrintJob:
            jeżeli jobs nie jest pusta:
                zwróć pierwszy element w jobs  // bez usuwania
            w przeciwnym razie:
                zwróć NULL

        metoda processNextJob() → PrintJob:
            jeżeli jobs jest pusta:
                wyświetl "Brak zadań w kolejce."
                zwróć NULL
            job ← usuń pierwszy element z jobs
            wyświetl "Drukuję: " + job
            // (tutaj symulacja druku – w praktyce wysłanie do sterownika drukarki)
            zwróć job

        metoda listJobs() → lista<PrintJob>:
            zwróć kopię kolekcji jobs   // tak, by nie ujawniać wewnętrznej struktury


// ---------------------------
// Przykładowy program główny (test)
// ---------------------------
funkcja main():
    // Pobieramy instancję bufora (Singleton)
    buffer1 ← PrintBuffer.getInstance()
    buffer2 ← PrintBuffer.getInstance()

    // Sprawdzamy, czy to rzeczywiście ta sama instancja
    wyświetl "buffer1 is buffer2 ? " + (buffer1 == buffer2)

    // Tworzymy i dodajemy kilka zadań
    job1 ← nowy PrintJob(1, "Dokument_A.pdf", 10)
    job2 ← nowy PrintJob(2, "Raport_B.docx", 5)
    job3 ← nowy PrintJob(3, "Prezentacja_C.pptx", 15)

    buffer1.addJob(job1)
    buffer1.addJob(job2)
    buffer1.addJob(job3)

    // Wyświetlamy stan kolejki
    wyświetl "\nAktualna kolejka zadań:"
    dla każdego zadania w buffer1.listJobs():
        wyświetl " - " + zadanie

    // Przetwarzamy zadania jedno po drugim
    wyświetl "\nProces drukowania:"
    dopóki TRUE:
        nextJob ← buffer2.getNextJob()
        jeżeli nextJob == NULL:
            przerwij pętlę
        buffer2.processNextJob()

    // Kończymy test i weryfikujemy pustą kolejkę
    wyświetl "\nKolejka po przetworzeniu wszystkich zadań: " + buffer1.listJobs()


// Uruchomienie programu:
wywołaj main()




## zadanie 3

@startuml
'========================
' Diagram UML – Builder
'========================

'------------------------
' Klasa: Pizza (Produkt)
'------------------------
class Pizza {
    - Dough: string
    - Meats: List<string>
    - Cheeses: List<string>
    - Veggies: List<string>
    - Spices: List<string>
    + Pizza()
    + SetDough(dough: string): void
    + AddMeat(meat: string): void
    + AddCheese(cheese: string): void
    + AddVeggie(veggie: string): void
    + AddSpice(spice: string): void
    + Describe(): string
}

'------------------------
' Interfejs: IPizzaBuilder
'------------------------
interface IPizzaBuilder {
    + Reset(): void
    + SetDough(dough: string): void
    + AddMeat(meat: string): void
    + AddCheese(cheese: string): void
    + AddVeggie(veggie: string): void
    + AddSpice(spice: string): void
    + GetPizza(): Pizza
}

'-------------------------------
' Klasa: ConcretePizzaBuilder
'-------------------------------
class ConcretePizzaBuilder {
    - _pizza: Pizza
    + Reset(): void
    + SetDough(dough: string): void
    + AddMeat(meat: string): void
    + AddCheese(cheese: string): void
    + AddVeggie(veggie: string): void
    + AddSpice(spice: string): void
    + GetPizza(): Pizza
}

'------------------------
' Klasa: Director
'------------------------
class Director {
    - _builder: IPizzaBuilder
    + Director(builder: IPizzaBuilder)
    + ConstructMargherita(): void
    + ConstructMeatLovers(): void
    + ConstructVeggieDelight(): void
}

'------------------------
' Klasa: Client (Main)
'------------------------
class Client {
    + Main(): void
}

'========================
' Relacje między klasami
'========================
ConcretePizzaBuilder ..|> IPizzaBuilder
Pizza <-- ConcretePizzaBuilder : tworzy >
Director --> IPizzaBuilder : używa >
Client --> Director : korzysta z >
Client --> IPizzaBuilder : korzysta z >

@enduml




### pseudokod

// --------------------------------
// Produkt: Pizza
// --------------------------------
class Pizza:
    atrybuty:
        dough: string
        meats: lista<string>
        cheeses: lista<string>
        veggies: lista<string>
        spices: lista<string>

    konstruktor Pizza():
        dough = ""
        meats = pusta lista
        cheeses = pusta lista
        veggies = pusta lista
        spices = pusta lista

    metoda SetDough(dough: string):
        this.dough = dough

    metoda AddMeat(meat: string):
        dodaj meat do this.meats

    metoda AddCheese(cheese: string):
        dodaj cheese do this.cheeses

    metoda AddVeggie(veggie: string):
        dodaj veggie do this.veggies

    metoda AddSpice(spice: string):
        dodaj spice do this.spices

    metoda Describe() → string:
        // Zwraca opis pizzy w formie wielowierszowego tekstu
        opis = "Pizza z następującymi składnikami:"
        opis += "\n  Ciasto: " + dough
        jeśli meats nie jest puste:
            opis += "\n  Wędliny: " + join(", ", meats)
        jeśli cheeses nie jest puste:
            opis += "\n  Sery: " + join(", ", cheeses)
        jeśli veggies nie jest puste:
            opis += "\n  Warzywa: " + join(", ", veggies)
        jeśli spices nie jest puste:
            opis += "\n  Przyprawy: " + join(", ", spices)
        zwróć opis


// --------------------------------
// Interfejs: IPizzaBuilder
// --------------------------------
interface IPizzaBuilder:
    metoda Reset(): void
    metoda SetDough(dough: string): void
    metoda AddMeat(meat: string): void
    metoda AddCheese(cheese: string): void
    metoda AddVeggie(veggie: string): void
    metoda AddSpice(spice: string): void
    metoda GetPizza() → Pizza


// --------------------------------
// Implementacja: ConcretePizzaBuilder
// --------------------------------
class ConcretePizzaBuilder implements IPizzaBuilder:
    prywatne:
        pizza: Pizza

    metoda Reset():
        pizza = nowa Pizza()

    metoda SetDough(dough: string):
        pizza.SetDough(dough)

    metoda AddMeat(meat: string):
        pizza.AddMeat(meat)

    metoda AddCheese(cheese: string):
        pizza.AddCheese(cheese)

    metoda AddVeggie(veggie: string):
        pizza.AddVeggie(veggie)

    metoda AddSpice(spice: string):
        pizza.AddSpice(spice)

    metoda GetPizza() → Pizza:
        gotowaPizza = pizza
        Reset()                           // zresetuj builder, aby nadać się do kolejnego użycia
        zwróć gotowaPizza


// --------------------------------
// Kierownik (Director): Director
// --------------------------------
class Director:
    atrybut:
        builder: IPizzaBuilder

    konstruktor Director(builder: IPizzaBuilder):
        this.builder = builder

    metoda ConstructMargherita():
        builder.Reset()
        builder.SetDough("Cienkie ciasto")
        builder.AddCheese("Mozzarella")
        builder.AddCheese("Parmezan")
        builder.AddSpice("Bazylia")

    metoda ConstructMeatLovers():
        builder.Reset()
        builder.SetDough("Grube ciasto")
        builder.AddCheese("Mozzarella")
        builder.AddMeat("Pepperoni")
        builder.AddMeat("Szynka")
        builder.AddMeat("Boczek")
        builder.AddSpice("Oregano")

    metoda ConstructVeggieDelight():
        builder.Reset()
        builder.SetDough("Cienkie ciasto")
        builder.AddCheese("Mozzarella")
        builder.AddVeggie("Papryka")
        builder.AddVeggie("Cebula")
        builder.AddVeggie("Pieczarki")
        builder.AddSpice("Oregano")
        builder.AddSpice("Czosnek w proszku")


// --------------------------------
// Klient (Client / Program)
// --------------------------------
funkcja Main():
    // Tworzymy builder oraz przekazujemy go do Director
    builder = nowy ConcretePizzaBuilder()
    director = nowy Director(builder)

    // 1) Pizza Margherita z użyciem Directora
    director.ConstructMargherita()
    margherita = builder.GetPizza()
    wyświetl "=== Pizza Margherita ==="
    wyświetl margherita.Describe()
    wyświetl "\n"

    // 2) Pizza Meat Lovers z użyciem Directora
    director.ConstructMeatLovers()
    meatLovers = builder.GetPizza()
    wyświetl "=== Pizza Meat Lovers ==="
    wyświetl meatLovers.Describe()
    wyświetl "\n"

    // 3) Pizza wegetariańska bez użycia Directora – klient sam wybiera składniki
    builder.Reset()
    builder.SetDough("Grube ciasto")
    builder.AddCheese("Mozzarella")
    builder.AddVeggie("Szpinak")
    builder.AddVeggie("Papryka")
    builder.AddVeggie("Cukinia")
    builder.AddSpice("Bazylia")
    builder.AddSpice("Oregano")
    customVeggie = builder.GetPizza()
    wyświetl "=== Pizza Wegetariańska (niestandardowa) ==="
    wyświetl customVeggie.Describe()

Koniec pseudokodu.
