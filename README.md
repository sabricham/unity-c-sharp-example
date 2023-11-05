# unity-c-sharp-example
Esempio di codice C# utilizzato nel motore grafico Unity per controllare i movimenti del giocatore (un pollo) all'interno di un gioco platformer.
Il gioco è un prototipo ideato per sistemi Android con visualizzazione Landscape (schermo 18:9 circa, orizzontale, di un dispositivo android).

![alt-text](https://github.com/sabricham/unity-c-sharp-example/blob/main/Dimostrazione.mp4 "Video dimostrazione") 

Il giocatore premendo sullo schermo interagisce con il pollo, il quale corre inarrestabile orizzontalmente in un ambientazione
con varie piattaforme ed ostacoli (ancora non presenti), l'interazione con il pollo è semplice: premendo sullo schermo esso
compie un salto e comincia a utilizzare le ali per "planare" e atterrare lentamente mentre prosegue il suo 
movimento laterale per inerzia, una volta riatterrato riprende la corsa.
Le animazioni e il modello colorato del pollo completano perfettamente il concept del videogioco.

Analizzando il lato tecnico:
Il codice utilizza diverse componenti all'interno di Unity, componenti appartenenti all'oggetto "pollo" o meglio Player/Giocatore, tra le quali
Animator (sistema di controllo dell'animazione del pollo) e Rigidbody (sistema di simulazione della fisica all'interno del motore).
Manipolando diversi membri e utilizzando alcuni metodi appartenenti a questi componenti si effettuano modifiche di velocità del personaggio
(la corsa inarrestabile e incrementale, orizzontale), modifiche di accelerazione del personaggio (spinta verso l'alto nel caso di un salto),
si sceglie quale animazione attivare del pollo (corsa, planata, salto) etc.
