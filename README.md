# SuperGirl World

SuperGirl Adventures és un joc d'acció i plataformes que transporta els jugadors a un món fascinant ple de desafiaments i aventures. Prendreu el control de SuperGirl, una heroïna amb superpoders, mentre navega per diferents nivells plens de plataformes, enemics i secrets emocionants.

Aprofita la teva força, velocitat i agilitat per superar tots els obstacles i salvar el món d'amenaces desconegudes. Benvingut a SuperGirl Adventures, on l'aventura espera cada cop que poses el peu al món del joc.

# Disseny i Desenvolupament

## Organització del Codi

He organitzat el codi seguint algunes convencions i pràctiques que considero importants per a la claredat, la modularitat i la col·laboració eficient.

### 1. Modularitat amb Carpeta de Scripts

He creat una carpeta "Scripts" per agrupar tots els scripts del joc. Aquesta modularitat facilita la identificació i la modificació de codi específic, ja que cada script té una funcionalitat concreta. També facilitaria la col·laboració, ja que els membres de l'equip podrien centrar-se en àrees específiques del joc.

### 2. Gestió d'Actius Visuals i Sonors

Els recursos visuals es troben a la carpeta "Sprites", mentre que els recursos sonors es troben a la carpeta "Audio". Aquesta separació facilita la gestió d'actius visuals i sonors, permetent un enfocament més específic quan cal treballar amb aquests elements.

### 3. Organització de Nivells amb Escenes

Cada nivell del joc es representa com una escena independent i es troba a la carpeta "Scenes". Aquesta organització facilita la gestió de diferents nivells i ofereix una estructura clara per als membres de l'equip que treballen en nivells específics.

### 4. Reutilització d'Elements amb Prefabs

He creat una carpeta "Prefabs" per emmagatzemar tots els prefabs que podrien ser reutilitzats en diversos nivells. Això permet dissenyar elements específics i reutilitzar-los sense recrear-los cada vegada, la qual cosa pot estalviar temps i mantenir una coherència en tot el joc.

L'objectiu és fer que el codi sigui clar, modular i fàcil d'entendre, tant per a mi com per altres membres de l'equip (si fos el cas).

## Tractament de Col·lisions

En el desenvolupament del meu joc, he posat molta atenció al tractament de col·lisions per garantir una interacció suau i realista entre els diversos elements del món del joc. Aquí hi ha algunes de les decisions que he pres i com he abordat aquest aspecte clau:

### 1. Sistema de Col·lisions Basat en Layers o Tags

He utilitzat un sistema de col·lisions basat en capes (layers) i etiquetes (tags) per assegurar-me que només interactuïn els objectes que ho han de fer. Això significa que, per exemple, la SuperGirl pot col·lidir amb les plataformes, però no amb les monedes, i viceversa. Aquest enfocament ha contribuït a evitar comportaments inesperats i a millorar la coherència en el joc.

### 2. Ajustament de les Màscares de Col·lisió

Per garantir una col·lisió precisa i evitar situacions incoherents, he ajustat les màscares de col·lisió en el colider 2D dels diferents objectes. Això assegura que només es detectin les col·lisions entre els elements que tenen una interacció prevista, millorant així la consistència del joc.

### 3. Maneig de Col·lisions en els Scripts

He implementat el maneig de col·lisions en els scripts pertinents, com ara el script de la SuperGirl i les caixes de monedes. Això em permet gestionar les conseqüències de les col·lisions de manera específica per a cada tipus d'objecte. Per exemple, quan la SuperGirl col·lideix amb una caixa de monedes, s'activa una seqüència específica que impulsa la caixa cap amunt i genera monedes.

Aquesta aproximació al tractament de col·lisions ha estat fonamental per garantir una experiència de joc fluida i coherent. L'ús de capes i l'ajustament de màscares de col·lisió han estat claus per mantenir la consistència en les interaccions del joc.

## Implementació del Salt i Moviments dels Personatges

En el desenvolupament del meu joc, he posat molta atenció a la implementació dels moviments dels personatges, garantint una jugabilitat fluida i responsiva. 

### 1. Control de Moviments

He utilitzat l'input d'Unity per gestionar els moviments de SuperGirl. He implementat un controlador de moviments que respon als inputs de l'usuari amb el teclat. Tant amb awsd com amb els cursors. Així facilita a l'usuari a utilitzar la mà que li sigui més còmoda. 

### 2. Salt Responsiu

Per al salt, he implementat una lògica que respon de manera immediata als inputs de l'usuari. Quan es prem la tecla de salt, s'aplica una força vertical al personatge, proporcionant un salt realista i dinàmic, gràcies també a l'animació aplicada. Aquesta implementació ofereix un control precís sobre els salts, permetent als jugadors ajustar la seva trajectòria en temps real.

### 3. Detecció de Col·lisions i Moviments Fluids

Per evitar moviments inconsistent, he implementat un sistema de detecció de col·lisions que impedeix que la SuperGirl atravessi plataformes i altres objectes. Això garanteix que els moviments siguin fluids i que el personatge interactuï correctament amb l'entorn.

### 4. Animacions de Moviment

He integrat animacions de moviment per millorar la sensació de moviment. Quan la SuperGirl es mou o salta, les animacions proporcionen una retroalimentació visual immediata als jugadors, millorant la immersió i l'experiència de joc.

En resum, la implementació dels moviments i el salt dels personatges ha estat una combinació de controls responsius, detecció de col·lisions precisa i elements visuals com les animacions. Aquest enfocament assegura una jugabilitat agradable i una interacció coherent amb el món del joc.

## Les Meves Dificultats i Solucions Durant el Desenvolupament

El procés de desenvolupament del meu joc no va ser exempt de reptes, i aquí comparteixo algunes de les dificultats que he tingut i com les he abordat:

### 1. **Problemes amb les Col·lisions Precises**

En una fase inicial, em vaig enfrontar a problemes amb les col·lisions, especialment en els límits dels objectes. Per abordar això, vaig ajustar les màscares de col·lisió i vaig utilitzar col·lisions basades en layers per garantir que només els objectes rellevants interactuissin. Aquesta solució va ajudar a millorar la precisió de les col·lisions i evitar comportaments inesperats.

### 2. **Animacions No Sincronitzades amb Accions del Personatge**

Inicialment, em vaig trobar amb problemes de sincronització entre les animacions i les accions del personatge, com ara els salts i els moviments. Per superar aquesta dificultat, vaig revisar els events d'animació i els vaig ajustar per assegurar-me que coincidissin perfectament amb les accions del personatge, millorant així la coherència visual.

### 3. **Gestió de l'Estat del Joc**

La gestió de l'estat del joc, com l'actualització de la puntuació, o el gameover va ser un repte. Vaig implementar un sistema de gestió d'actualitzacions eficients de la puntuació quan es produïen certes accions al joc.

### 4. **Optimització de Rendiment**

En una fase avançada, em vaig adonar que el rendiment podia ser un problema amb l'aparició de molts elements alhora. Vaig implementar tècniques d'optimització, com la desactivació d'objectes fora de la càmera i la reducció de la complexitat de certes operacions, per millorar el rendiment general del joc.

Aquestes dificultats han estat oportunitats per aprendre i millorar el meu procés de desenvolupament. Cada desafiament superat ha contribuït a fer del meu joc una experiència més robusta i atractiva.

## Recursos Utilitzats

### Sprites

Els sprites utilitzats en aquest joc provenen de les següents pàgines:

- [OpenGameArt](https://opengameart.org/)
- [CraftPix](https://craftpix.net/freebies/)

Agraïm als creadors d'aquests recursos per compartir-los amb la comunitat de desenvolupament de jocs.

### Música

La música utilitzada en aquest joc és proporcionada per [Artlist](https://artlist.io/).

