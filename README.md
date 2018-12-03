# Unity Factory app

Určené pre mobilné zariadenia (Android, iOS) s využitím technológie VR.

## Kľúčové body

* Pohybuje sa _Player_, nie _Main Camera_. Player má ako collider tvar kapsuly (CapsuleCollider)
* Collidery zabraňujú prieniku medzi sebou
* TerrainCollider zabraňuje prepadnutiu "cez zem"
* MeshCollider zabraňuje prechodu na základe celého jeho tvaru
* Ak má polžka komponent _RigidBody_ tak je na ňu aplikovaná gravitácia.

## Skripty

### Player controller

Má za úlohu pohybovať s hráčom hráč sa môže pohybovať len keď je na zemi (dôsledok: nepohodlné lezenie "na kopec"). Hráč sa pohybuje pomocou horizontálnej osi joysticku len v smere, kam sa pozerá. Podpora pre skok.

### Lift controller

Obsluhuje výťah a kontoluje stlačenie tlačidla. Kontroluje to eventami `OnEnter` - pozretie sa na tlačidlo a `OnLeave` - pozretie sa mimo tlačidla. Pri stlačení tlačidla na joysticku sa do input stringu dostane enter (`\n`) s ascii hodnotou 10. Nanešťastie program to nevníma ako stlačenie enteru preto sa porovnáva ascii hodnota tlačidla s hodnotou 10. Po zistení stlačenia tlačidla sa začne pohybovať výťah spôsobom:

1. Horizontálna plocha nahor
2. Vertikálna plocha dopredu
3. Vertikálna plocha dozadu
4. Horizontálna plocha nadol

Výsledkom je posunutie krabice na vyvýšené miesto. Animovanie funguje na základe delta času a konštanty `speed`, ktorá značí rýchlosť animovania.
