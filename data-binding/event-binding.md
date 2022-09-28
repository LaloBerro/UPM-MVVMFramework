# Event Binding

### Button Component

Para poder invocar a un event necesitamos por ahora esta disponible solo para Buttons, estos implementan la interface IButtonView, en este caso OnClickButtonView nos invoca el EventPropertyViewModel cuando es clickeado.

Entonces añadimos el component OnClickButtonView:

### ![](<../.gitbook/assets/Untitled (3) (1).png>)

### EventBindingViewModel

Este ViewModel es un ScriptableObject y contiene un ReactiveCommand que reacciona cuando el boton es clickeado.

<figure><img src="../.gitbook/assets/Untitled (4).png" alt=""><figcaption></figcaption></figure>
