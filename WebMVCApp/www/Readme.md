---
__Advertisement :)__

- __[pica](https://nodeca.github.io/pica/demo/)__ - high quality and fast image
  resize in browser.
- __[babelfish](https://github.com/nodeca/babelfish/)__ - developer friendly
  i18n with plurals support and easy syntax.

You will like those projects!
---


# LEER PRIMERO!

## Descripcion de este Directorio ( www/ )

En este directorio usted encontrara lo siguiente:

+ **css/ ,** Guarda los css que uno mismo desarrolla, que es implementacion de librerias css.  `+`, `-`, or `*`
+ **js/ ,** Guarda los Javascripts que uno mismo desarrolla, que es implementacion de librerias JS.
+ **vendor/ ,** Almacena libreria de terceros (p.ejm jquery), normalmente se crea automaticamente con herramientas como npm o bower. (para nuestro caso se creo manualmente.)
+ **vueapp/ ,** Carpeta creada para agregar scripts basados en VueJS. Dentro de el, tenemos lo sgte:
  - **[ctrl_name]/ ,** Carpeta que contendra un archivo **index.js** (segun la convencion y definicion dentro del archivo webpack.config.js), este archivo tendra implementaciones Propias de cada controller.
+ **.gitignore ,** Archivo para ignorar directorios o archivos generados por las herramientas automatizadas. por ejm, **bundle/** se genera automaticamente por webpack, este se ignora dentro de este archivo.
+ **package.json ,** Archivo de dependecias para npm. Este genera un directorio: **node_modules/**, el cual esta ignorado gracias al **.gitignore** .
+ **webpack.config.js ,** Archivo de configuracion para trabajar con Webpack.

## Requisitos minimos y Pasos iniciales

+ Tener instalado NodeJS (para window o Linux). Esto instala nodejs y npm (manejador de paquetes.)
+ Ejecutar: _**npm run build**_ el comando Build esta definido dentro de la seccion scripts en el archivo: **package.json**.
Es importante tener creado las carpetas () dentro de vueapp con el archivo index.js en cada carpeta.






(c) (C) (r) (R) (tm) (TM) (p) (P) +-

test.. test... test..... test?..... test!....

!!!!!! ???? ,,  -- ---

"Smartypants, double quotes" and 'single quotes'


## Emphasis

**This is bold text**

__This is bold text__

*This is italic text*

_This is italic text_

~~Strikethrough~~



## Code

Inline `code`

Indented code

    // Some comments
    line 1 of code
    line 2 of code
    line 3 of code


Block code "fences"

```
Sample text here...
```

Syntax highlighting

:   Definition 1
``` js
var foo = function (bar) {
  return bar++;
};

console.log(foo(5));
```

## Tables

| Option | Description |
|--------|-------------|
| data   | path to data files to supply the data that will be passed into templates. |
| engine | engine to be used for processing templates. Handlebars is the default. |
| ext    | extension to be used for dest files. |

Right aligned columns

| Option | Description |
| ------:| -----------:|
| data   | path to data files to supply the data that will be passed into templates. |
| engine | engine to be used for processing templates. Handlebars is the default. |
| ext    | extension to be used for dest files. |


## Links

[link text](http://dev.nodeca.com)

[link with title](http://nodeca.github.io/pica/demo/ "title text!")

Autoconverted link https://github.com/nodeca/pica (enable linkify to see)


## Images

![Minion](https://octodex.github.com/images/minion.png)
![Stormtroopocat](https://octodex.github.com/images/stormtroopocat.jpg "The Stormtroopocat")

Like links, Images also have a footnote style syntax

![Alt text][id]

With a reference later in the document defining the URL location:

[id]: https://octodex.github.com/images/dojocat.jpg  "The Dojocat"


## Plugins

The killer feature of `markdown-it` is very effective support of
[syntax plugins](https://www.npmjs.org/browse/keyword/markdown-it-plugin).


### [Emojies](https://github.com/markdown-it/markdown-it-emoji)

> Classic markup: :wink: :crush: :cry: :tear: :laughing: :yum:
>
> Shortcuts (emoticons): :-) :-( 8-) ;)

see [how to change output](https://github.com/markdown-it/markdown-it-emoji#change-output) with twemoji.


### [Subscript](https://github.com/markdown-it/markdown-it-sub) / [Superscript](https://github.com/markdown-it/markdown-it-sup)

- 19^th^
- H~2~O


### [\<ins>](https://github.com/markdown-it/markdown-it-ins)

++Inserted text++


### [\<mark>](https://github.com/markdown-it/markdown-it-mark)

==Marked text==


### [Footnotes](https://github.com/markdown-it/markdown-it-footnote)

Footnote 1 link[^first].

Footnote 2 link[^second].

Inline footnote^[Text of inline footnote] definition.

Duplicated footnote reference[^second].

[^first]: Footnote **can have markup**

    and multiple paragraphs.

[^second]: Footnote text.


### [Definition lists](https://github.com/markdown-it/markdown-it-deflist)

Term 1

:   Definition 1
with lazy continuation.

Term 2 with *inline markup*

:   Definition 2

        { some code, part of Definition 2 }

    Third paragraph of definition 2.

_Compact style:_

Term 1
  ~ Definition 1

Term 2
  ~ Definition 2a
  ~ Definition 2b


### [Abbreviations](https://github.com/markdown-it/markdown-it-abbr)

This is HTML abbreviation example.

It converts "HTML", but keep intact partial entries like "xxxHTMLyyy" and so on.

*[HTML]: Hyper Text Markup Language

### [Custom containers](https://github.com/markdown-it/markdown-it-container)

::: warning
*here be dragons*
:::
