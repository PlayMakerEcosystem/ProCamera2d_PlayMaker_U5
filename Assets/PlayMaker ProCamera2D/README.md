PlayMaker--ProCamera2D
================

## Licensing
This package is released under LGPL license: [http://opensource.org/licenses/LGPL-3.0](http://opensource.org/licenses/LGPL-3.0)


## Description
This is a set of proxy component to bridge ProCamera2D and PlayMaker. It basically forwards ProCamera2D events as PlayMaker events.

## Implementation
- Drop the proxies on any GameObject, it will by default pick up the MainCamera but you are free to target the owner of that component or an arbitrary GameObject
- Select for each ProCamera2d events te PlayMaker Event to send
- Notice the Event Properties description, they define the keys associated with each events, use `GetEventProperties` to retrieve these properties when you receive PlayMaker's event.


