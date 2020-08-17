
let data: number | string;


data = '43';


let numero: number = 23;

export interface Icar {
    color: string;
    model: string;
    topSpeed?: number;
}

const car1: Icar = {
    color : "rojo",
    model : "civic",
}

const car2: Icar = {
    color : "azul",
    model : "toyota",
}

const multiply = (x: number, y: number): string | number => 
{
    return x*y;
}

export const cars = [car1, car2];