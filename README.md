---
description: >-
  MVVM Framwork es un package que nos va a proporcionar las base para
  implementar MVVM en Unity.
---

# Introduccion

## Que es MVVM&#x20;

MVVM (Model View View Model) es patron de arquitectura, esto quiere decir que va a condicionar la estructura de nuestro proyecto y nos va a facilitar la comunicacion del equipo y no vas a dar herramientas para escribir codigo mas limpio, extensible, entendible y testeable.

## Capas

En esta implementacion de MVVM se toma de base la CleanArchitecture (CA), por lo que por fuera se vera como CA pero por dentro tendra elementos de MVVM.



<figure><img src=".gitbook/assets/Diagrama sin título (4).png" alt=""><figcaption></figcaption></figure>

### View

Es la encarga de contener todas las referencias al editor relacionadas con el usuario, estas serian Button, Text, InputField, Slider, en general cualquier elemento de la UI.

Es la unica que va a heredar de Monobehaviour.

La View se comunica con el ModelView y el controller.

### Interface Adapters

Esta capa es la encargada abstraer las carasteristicas de la View para que puedan ser consumidas por el Domain y de implementar algunos detalles del Domain, tal como los gateways.

Esta se devide en varias sub-capas:

#### ModelView

Es la encargada de almacenar los eventos y variables del programa, esta se implementa de una forma reactiva. Funciona como un mediator entre la View y el Presenter y entre la View y el Controller.

#### Presenter

&#x20;Es el encargado de recibir los datos del Domain y formatearlos para pasarselos al ModelView.

#### Controller

&#x20;Es el encargado de recibir los inputs del ModelView y de llamar al Domain para decirle que hacer.

#### Gateways

Son los encargados de implementar las llamadas un servidor a base de datos y siempre implementan interfaces del Domain.

### Domain

El model es el encargado de almacenar toda la logica de negocio.&#x20;

Se divide en sub-capas:

#### UseCases

Es la encargada de almacenar la logica de negocio y todos los casos de uso que vendrian a ser las acciones especificas de un sistema.

#### Entities

Esta capa es la encargada de almacenar todas las Entities, estas son todas las clases que almacenan datos y funciones que cambian esos datos, es una aproximacion al concepto de object.



































