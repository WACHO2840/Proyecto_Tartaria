![logo](/img/image.png)
## INDICE.

- [Introduccióón](#Introducción)
- [Mapa mental](#Mapamental)
- [Notas del los personajes](#Notasdelospersonajes)
- [Armas](##Armas)

# Introducción

En la actualidad, la industria de los videojuegos es una de las mayores formas de entretenimiento a nivel mundial. La tecnología avanza con el paso de los años, lo que provoca que las herramientas para el desarrollo de videojuegos sean más accesibles para todos los públicos.
Tartaria es un juego basado en el género “roguelike”, el cual dentro de los juegos de rol destaca por enfrentar al jugador a niveles con temática de mazmorras, laberintos y una muerte permanente. Todo esto combinado con la estética de los años 80 y 90. Este juego se desarrolla en el motor gráfico de Unity y se lleva a cabo con herramientas como GitHub para la coordinación.
Se consideró hacer este proyecto en el motor de Unreal Engine 5 (/img/UE 5), pero se acabó descartando debido a la complejidad de este, por lo que el otro motor disponible es Unity, el cual es más claro y sencillo en comparación.
Todo el juego está desarrollado en C #, se utiliza una estructura básica del código, pero es necesario aprender los nuevos conceptos que se enfocan específicamente en el desarrollo de videojuegos. Se puede crear y examinar varias funcionalidades para el personaje principal y los NPC, incluidos los enemigos que se encuentran a lo largo del recorrido, y los objetos que nos ayudan a mejorar las estadísticas del jugador, lo cual será de ayuda durante el recorrido. Los enemigos tienen la misión de complicar todo lo posible el camino por los diferentes niveles, algunos se pueden ver venir y se puede estar listo para actuar, pero otros estarán esperando para atacar en el momento menos esperado
Esta idea implica un aprendizaje continuo en todos los aspectos técnicos, los diferentes diseños aplicados en los objetos, mapas, personajes, enemigos, plataformas… La implementación de los niveles, unión y corrección de errores que no se habían experimentado antes. La imaginación y la puesta en escena para el decorado de los sprite que aparecen en el videojuego.

# Mapa mental

![->](/img/mapaMental2.png)

# Notas de los personajes

> [JUGADOR]
>
> El jugador es el único personaje que el usuario puede controlar. Una vez comienzas la partida tienes que elegir el arma que te acompañara durante toda la partida, avanzando en la misma se encuentran diferentes objetos que proporcionan un extra a este personaje.
> Dependiendo de los objetos elegidos por el usuario durante el transcurso del juego este acabara con diferentes estadísticas/habilidades, pero tiene limitaciones, esta incluye un máximo de 3 objetos a la vez.
>
>![->](/img/NPC.png)

> [NPC]
>
> Los personajes no jugables (NPC) son una parte importante dentro de la arquitectura de un juego, ya que es responsable de proporcionar orientación y aprendizaje necesario al jugador. Estos personajes son útiles en la comprensión de las mecánicas del juego y el entorno en general, aparte de tener un papel fundamental en la entrega de la narrativa y la dinámica del juego.
>
>![->](/img/NPC2.png)

> [ENEMIGO]
>
> Los enemigos son los antagonistas del jugador. Equipados para el combate cuerpo a cuerpo, estos enemigos siguen rutas predefinidas de patrulla y exhiben una variedad de comportamientos durante el juego, ofreciendo diferentes desafíos y enfrentamientos para dificultar el progreso al jugador.
>
>![->](/img/Enemigo1.png)
>![->](/img/EnemigoVolador1.png)
>![->](/img/Rata.png)
>![->](/img/Glovo.png)

## Armas

| Imagen | Nombre   | Descripción |
|--------|----------|-------------|
| ![->](/img/Katana.png) | Katana | Daño = 5 - Velocidad de ataque = 1.5 - Rango = 1.5Daño = 5 - Velocidad de ataque = 1.5 - Rango = 1.5 |
| ![->](/img/Mazo.png) | Mazo | Daño = 12 - Velocidad de ataque = 2 - Rango = 1.2 - Daño = 12 - Velocidad de ataque = 2 - Rango = 1.2 |