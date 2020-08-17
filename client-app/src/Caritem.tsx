import { Icar } from "./demo";
import React from 'react';

interface IProps
{
    car : Icar
}

const CarItem: React.FC<IProps> = ({car}) =>
{

    return (
        <div>
            <h1>{car.color}</h1>
        </div>
    )

}

export default CarItem;