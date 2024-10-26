const base = {
    name: "Navneet",
    __proto__: {
        myname: myname
    }
}

function myname() {
    console.log(`my name is ${this.name}`);
}

base.myname();

// creating new object with considering 'base' as prototype 
const child = Object.create(base);
child.name = "Mayur";
child.myname();
