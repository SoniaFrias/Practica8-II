# Practica8

Práctica 8 de Interfaces Inteligentes

* **Autor:** Sonia Frías Jiménez 
* **ALU** alu0101492513@ull.edu.es
* **Versión de Unity:** 6.6

El objetivo de la práctica es construir una aplicación de RA con Unity utilizando AR Foundation-AR Core ampliando la funcionalidad del proyecto de ejemplo de Google. Consiste en un juego simple donde el usuario controla un coche que recoje regalos.

# Tutorial
Se ha seguido las instrucciones detalladas de la guia de Google [AR Foundation - AR Core](https://codelabs.developers.google.com/arcore-unity-ar-foundation#1).

Primero se ha creado un proyecto vacio con la plantilla Universal Render Pipeline. Luego se han instalado directamente desde Unity Registry los paquetes necesarios: `AR Foundation` y `Google ARCore XR Plugin` y se ha importado el paquete `starter-package.unitypackage`. A continuación, se ha configurado la compilación del proyecto para Android, utilizando la escena de ejemplo y añadiendo el pluggin.

1. Configuración de la cámara

Tras la configuración inicial, se pasa a la creación de la escena añadiendo el AR Session y AR Session Origin. Este último ya no existe componente en la versión actual de Unity, por lo que en su lugar se crea un objeto vacio y creamos una cámara como hija añadiendole los componentes que se describen en el tutorial. 

2. Detección de planos

* Se agrega el componente ARPlaneManager y lo configura estableciendo el campo Plane Prefab.
* Se Agrega un componente ARRaycastManager 
* Agrega un componente de DrivingSurfaceManager: permite seleccionar un plano. Una vez que se selecciona un ARPlane, se ocultan todos los demás planos y se inhabilitan los planos nuevos.

3. Posicionamiento de la retícula y movimiento del coche

Se crea la retícula junto con su script de comportamiento siguiendo los pasos y añadiendo el código especificado por el tutorial. Luego se añaden el coche de juguete con su prefab y CarManager y el regalo con su prefab y PackageManager.

4. Configuración de la iluminación

Finalmente, se añaden unas líneas de código para detectar la iluminación presente en el mundo real y adaptar la iluminación de la escena para que coincida con la iluminación del mundo real.

### Visualización en una sala iluminada
![gif](gifs/luz.gif)

### Visualización en una sala poco iluminada

![gif](gifs/sinluz.gif)

# Adaptación del juego

Se ha adaptado el juego añadiendo la mecánica de puntuación donde alcanzar un paquete suma 1 punto y una araña resta 1 punto.

Para ello se ha creado un objeto Spider Spawner, como se hacía en el tutorial con los regalos. Y se le ha añadido el script PackageManager, pues el comportamiento debe ser el mismo. Se configura el prefab de araña correspondiente, para ello es necesario escalarlo, añadirle una etiqueta y un collider trigger, si no se añade el juego no detectará las colisiones con las arañas y da lugar a un bug donde se crean cientas de arañas. y la puntuación se muestra en pantalla. 

Para el control de la puntuación se ha modificado el script `CarBehaviour.cs`, de forma que distinga cuando se produce una colisión con un regalo y cuando con una araña, mandando un evento con la puntuación a modificar. Para mostrar la puntuación se ha creado un canvas con un texto y que está suscrito al evento que lanza CarBehaviour y en respuesta actualiza los mensajes de puntuación. Dichos scripts se pueden ver en el directorio [scripts](./scripts/).

Si el juego tuviera mecánicas más complejas sería conveniente separar el comportamiento de las arañas y regalos en scripts diferentes y que cada objeto gestionase la respuesta ante la colisión. 

### Prueba

![gif](gifs/gif_prueba.gif)

# APKS

APK con el ejemplo: [apk1](apks/RAprueba6.apk)

APK con la adaptación: [apk2](apks/RAprueba.apk)