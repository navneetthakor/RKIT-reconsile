# Abstract
- This, package includes my learning during RKIT (Company where i got my first job) Training period.
- It's entirely created and managed by,
    - Navneet Kumar (@navneetthakor)


# Bootstrap 5

## Intoduction
- It's latest version of bootstrap
- Supports all major borwsers but, internet explorer 11 and down are not supported.
- What new it has compare to older versions is,
    - switech to ```Javascript``` instead of ```JQuery``` and because of that,
        - improved performance, as now the this size of javascript code needed to load is reduced.
        - Better DOM interection due to use of native javascript methods which are more efficient compare to JQuery.
    - Added new componentes

## Ways to use Bootstrap
- Include it from ``` CDN (Content Delivery Network) ``` as follow4
    - CSS
    ```
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    ```

    - Javascript
    ```
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    ```

- Second way is we can download ``` Compiled version ``` as well as ``` source file version ``` from thier website.
- It also allows to pull it, from well known package managers. like for ``` NPM ```
    ```
    npm install bootstrap
    ```

## Important Features
### Break-points
- Following are the break-points that we have in Bootstrap
    ```
        xs:  <  576px,
        sm:  >= 576px,
        md:  >= 768px,
        lg:  >= 992px,
        xl:  >= 1200px,
        xxl: >= 1400px
    ```
- This breka-points are very Important in developoing responsive layouts.


### Containers
- This are used to pad contains.
- mainly 2 types of classes
    - ``` .container ``` which is fixed length container
    - ``` .container-fluid ``` which is full width contianer


### Grid System
- Grid is build with the helop of flex-box.
- It supports upto 12 column in single row.
- syntax for creating grid 
    ```
    <div class="row">
        <div class="col">col1</div>
        <div class="col">col2</div>
        <div class="col">col3</div>
    </div>
    ```
    - It will create single row.
    - for multi row grid add multiple such div tags.

- comman classes used in Grid system are follows.
    - ``` .row ``` - It will create single row of grid system.
    - ``` .col ``` - to create columns of equal-size. (it will wrapped accourding to default settings for smaller   screen sizes)
    - ``` .col-size ``` - defined screen and above it will create equal size columns. But, below that it will create stacked columns, means single column in each line.
        - size can take following values: ```sm | md | lg | xl | xxl ```, 
    - ``` .col- size - width``` - simillar to above but, column will be of different size.
        - width can take values in range 1 to 12
    - ``` .offset-size``` - to leave blank space


# Javascript

## Javascript Introduction
- Javascript is the scripting language used for writing logic in the website by means,
to create dynamic website.


## Ways to include javascript
- script can be placed either in ``` <head> ``` or ``` <body> ``` tag, with the help of ``` <script> ``` tag.
- Generally, placing script at the end of ``` <body> ``` tag is preferable, as it will result in faster page loading. As,
    - JS is blocking in nature so, whenever browser enconters ``` <script> ``` tag it stops the execution of rendering visual content and starts loading script.

- we can write JS directly in the script tag like,
    ```
    <script>
    let a = 5;
    console.log(a);
    </script>
    ```

    or we can write script in seprate file and then, load in the web-page.

    ```
    <script src="./script.js" > </script>

