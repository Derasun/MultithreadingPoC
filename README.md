# MultithreadingPoC

# Wat is multithreading?
Een thread van een proces voert achtereenvolgend opdrachten uit die de developer heeft gespecificeerd. Iedere applicatie heeft tenminste een thread(main thread), maar kan meer threads starten om taken tegelijkertijd uit te voeren. Ieder computer proces heeft een cpu register, program of instruction pointer en een stack. Een proces kan op een of dus meerdere threads (multi threading) runnen. Iedere thread heeft ook een eigen stack, cpu register en instruction pointer. De heap en static/global data zijn gedeeld.
In een computer met meerdere cpu cores kunnen processen en threads parallel worden uitgevoerd als dit zo is developed.

# Wanneer gebruik je meerdere threads?
Je kunt threads gebruiken om instructies op uit te voeren zonder de main thread te onderbreken.  Het voordeel ervan is dat een programma sneller kan zijn, door taken die paralel kunnen worden uitgevoerd te verdelen over verschillende threads. Een ander voordeel is dat je programma beter blijft reageren, bijvoorbeeld als men in Word een afdrukvoorbeeld wil genereren en afdrukken, dan kun je evengoed blijven werken en blijft Word niet "hangen"/ wachten totdat het voorbeeld gegenereerd of afgedrukt is. 

# Wat zijn drie veel voorkomende problemen bij multithreaded applications? Waardoor ontstaan ze?
Het feit dat verschillende threads data uit de heap delen is een voor- en nadeel. Het is een voordeel omdat het communicatie tussen threads vergemakkelijkt. Het nadeel is dat ze elkaar in de weg kunnen zitten en crashes van het proces kunnen veroorzaken. Debuggen en testen ervan is moeilijk, omdat problemen erg timing-afhankelijk en moeilijk te identificeren zijn: ze manifesteren vaak pas onder stressvolle condities. Problemen die zich voordoen:

1) Race: Races doen zich bijvoorbeeld voor als twee threads beide een counter willen ophogen. De threads hebben hun eigen register waar de waarde tijdelijk wordt opgeslagen (t.b.v. snelheid) en daarna wordt de waarde opgeslagen in de heap (bij object fields) of het data-segment op de RAM (globals en statics). Terwijl de waarde in een register zit heeft een andere thread er geen weet van. Als beide threads hun resultaat willen opslaan in RAM kan een ophoging worden gemist. 
2) Deadlock: Dat gebeurt als een thread een exclusive resource (lock) kan vasthouden, terwijl hij op een andere wacht. Als threads vervolgens cyclisch deze resources opvragen kunnen ze elkaar blokkeren. Een oplossing is om meerdere van deze resources (locks) altijd in dezelfde volgorde op te vragen, dan sluiten threads netjes achter in de rij aan.
3) Starvation: Als een thread een bepaalde resource vaak nodig heeft, maar te weinig kan bereiken omdat een zware taak in een andere thread de toegang te veel blokkeert.

# Hoe wordt het onderdeel genoemd waar objecten in het geheugen worden geplaatst?
Dit wordt de Heap genoemd

# Hoe is dit verschillend in een multithreaded application?
Er zijn geen verschillen.

# Hoe wordt het onderdeel genoemd waar methoden worden uitgevoerd en primitive types in het geheugen worden geplaatst?
Dit wordt de Stack genoemd.

# Hoe is dit verschillend in een multithreaded application?
Iedere thread heeft zijn eigen Stack, waardoor er dus meerdere stacks beschikbaar zijn.

# Wat is in dit kader een racing condition? Hoe zou je dit kunnen voorkomen?
Dit zijn de condities waarbij een Race kan ontstaan:
1 memory locatie die te bereiken is vanuit meerdere threads
2 eigenschap van de data in die locatie die van belang is voor juiste uitvoering van programma
3 de eigenschap klopt niet op elk moment
4 een andere thread krijgt toegang op dat moment

Beter voorkomen, dan genezen: 
- 1 en 2 zijn deels te beperken door gebruik van globals en statics te vermijden, en state te minimaliseren
- 3 voorkomen door objecten immutable te maken, dus fields final (const) te maken. 
- 4 voorkomen door te werken met Locks:

	C#: lock(lockObject){}
	Under the hood worden in .NET methodes Enter en Exit van System.Threading.Monitor gebruikt. Deze laten weten of een thread toegang heeft. Andere threads wachten dan tot het Lock-object (Object class) vrijgegeven is, voordat zij toegang krijgen. De Monitor class heeft meer bruikbare methodes om threads te laten samenwerken. 
	
	Java: synchronized(lockOject){} 
	Dit doet hetzelfde in Java. Het lockObject moet een instantie van de Lock class zijn. Je kunt ook het synchronized keyword in de signatuur van een methode gebruiken, dan wordt het parent object (this) als lock object gebruikt en heb je niet de flexibliteit van een custom lock object. Daarnaast kun je in Java (vergelijkbaar met C#) werken met lockObject.lock() (C# Enter) en .unlock (C# Exit) voor nog meer flexibiliteit. 
	

# Bronnenlijst

https://docs.microsoft.com/nl-nl/archive/blogs/vancem/encore-presentation-what-every-dev-must-know-about-multithreaded-apps
https://www.webucator.com/how-to/how-prevent-race-conditions-java-8.cfm
https://medium.com/swlh/race-conditions-locks-semaphores-and-deadlocks-a4f783876529
https://www.pluralsight.com/guides/lock-statement-access-data

https://en.wikipedia.org/wiki/Multithreading_(computer_architecture)
https://marcja.wordpress.com/2007/04/06/four-reasons-to-use-multithreading/
https://www.backblaze.com/blog/whats-the-diff-programs-processes-and-threads/
