import React from "react";
import { useState } from "react";
import "./calculadora.css";
import Boton from "./boton";

const Calculadora = () => {
  const [data, setData] = useState({ operacion: "", resultado: "" });
  //const escritura = (evento)=>{}//funcion
  const escritura = (evento) => {
    if (data.operacion.length >= 10) return; //condicional para solo tener un maximo de 10 digitos
    //setData({...data})=>copia lo que tenga data exactamente hasta ese punto
    /**
     * para guardar el valor en este caso de operación, se modifica la propiedad con el valor
     * que entra al hacer click es evento.target.innerText, sera el valor que tenga en el display
     */
    //evento.target.innerText => contiene el valor o el texto del boton, por lo que actualiza con
    //con el nuevo valor operacion
    setData({ ...data, operacion: data.operacion + evento.target.innerText });
  };
  //función para ir borrando el último caracter que tenga el display
  const eliminar = () => {
    //operacion.slice(0,data.operacion.length -1) => va desde cero hasta la length -1
    //va a ir eliminando la ultima posición dejando los restantes.
    setData({
      ...data,
      operacion: data.operacion.slice(0, data.operacion.length - 1),
    });
  };
  //función para borrar el estado completo del display
  const limpiar = () => {
    //se vuelve al estado iniciar
    setData({ operacion: "", resultado: "" });
  };
  //función para mostrar el resultad de la operación
  const resultadoOperacion = () => {
    //La función eval() en JavaScript toma una cadena que representa una expresión JavaScript y
    //la evalúa, es decir, la ejecuta como código JavaScript y devuelve el resultado de
    //esa evaluación
    /**
     * ejmplo
     * const resultado = eval("2 + 2");
     * console.log(resultado); // Output: 4
     */
    const resultado = eval(data.operacion);
    //se actualiza setData resultado con la variable resultado
    setData({
      ...data,
      resultado,
    });
  };
  return (
    <main>
      <span className="resultado">{data.resultado}</span>
      <span className="display">{data.operacion}</span>
      {/**parametros que pasa al componente "Boton" */}
      <Boton texto="C" clase="gris" handleClick={limpiar} />
      <Boton texto="+/-" clase="gris" />
      <Boton texto="%" clase="gris" />
      <Boton texto="/" clase="operacion" handleClick={escritura} />
      <Boton texto="7" clase="numero" handleClick={escritura} />
      <Boton texto="8" clase="numero" handleClick={escritura} />
      <Boton texto="9" clase="numero" handleClick={escritura} />
      <Boton texto="*" clase="operacion" handleClick={escritura} />
      <Boton texto="4" clase="numero" handleClick={escritura} />
      <Boton texto="5" clase="numero" handleClick={escritura} />
      <Boton texto="6" clase="numero" handleClick={escritura} />
      <Boton texto="-" clase="operacion" handleClick={escritura} />
      <Boton texto="1" clase="numero" handleClick={escritura} />
      <Boton texto="2" clase="numero" handleClick={escritura} />
      <Boton texto="3" clase="numero" handleClick={escritura} />
      <Boton texto="+" clase="operacion" handleClick={escritura} />
      <Boton texto="." clase="numero" />
      {/**Cuando hace click en un boton ejecuta la funcion escritura */}
      <Boton texto="0" clase="numero" handleClick={escritura} />
      <Boton texto="<-" clase="numero" handleClick={eliminar} />
      <Boton texto="=" clase="operacion" handleClick={resultadoOperacion} />
    </main>
  );
};
export default Calculadora;
