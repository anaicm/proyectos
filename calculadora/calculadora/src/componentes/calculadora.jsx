import React from "react";
import { useState } from "react";
import "./calculadora.css";
import Boton from "./boton";

const Calculadora = () => {
  const [data, setData] = useState({ operacion: "", resultado: "" });
  //const escritura = (evento)=>{}//funcion
  const escritura = (evento) => {
    //evento.target.innerText => contiene el valor o el texto del boton, por lo que actualiza con
    //con el nuevo valor operacion
    const valor = evento.target.innerText;
    //variable que guardara si es una operación
    const esOperacion =
      valor === "+" ||
      valor === "-" ||
      valor === "*" ||
      valor === "/" ||
      valor === "%";
    if (data.operacion.length >= 10) return; //condicional para solo tener un maximo de 10 digitos
    if (valor === "+/-" && data.operacion === "") return; //no pinta nada por pantalla
    //si ya hay un porcentaje y contiene el signo porcentaje no pinte nada
    if (valor === "%" && data.operacion.includes("%")) return; 

    if(data.operacion.includes("Error") && valor !=='='&& valor !=='C'){// si ya ha tenido un error anteriormente 
        //cambia el valor de data operacion por el valor por el valor que recibe y limpia resultado
        setData({operacion:valor, resultado:""});
        return;
    }//si ya ha realizado alguna operación 
    else if(data.resultado!=="" && esOperacion){
        setData({
            ...data,
            operacion: data.resultado + valor,//coge el valor que hay en resultado y realiza la operacion siguiente
           
          });
          return;
    }
    if (valor === "+/-" && data.operacion !== "") {//si se pulsa el boton +/- y hay un numero 
        if(data.operacion.slice(0,1)==='-'){//si el valor es negativo lo cambia a positivo
            setData({
                ...data,
                operacion: data.operacion.slice(1, data.operacion.length),
              });
        }else{//si el valor es positivo lo cambia a negativo
            setData({
                ...data,
                operacion: '-'+data.operacion,//agrega el signo menos al inicio de la cadena 
              });
        }
    } else {
      //setData({...data})=>copia lo que tenga data exactamente hasta ese punto
      /**
       * para guardar el valor en este caso de operación, se modifica la propiedad con el valor
       * que entra al hacer click es evento.target.innerText, sera el valor que tenga en el display
       */
      setData({ ...data, operacion: data.operacion + valor });
    }
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
    // const resultado = eval(data.operacion);
    // //se actualiza setData resultado con la variable resultado
    // setData({
    //   ...data,
    //   resultado,
    // });
    /**con try y catch podemos validar si existen errores*/
    try {
      //en try el codigo que quiero que se realice si todo está correcto
      let resultado; //eval(data.operacion);=> ya realiza la operación pero no realiza porcentajes
      if(data.operacion.includes("%")){//si la operación es porcentaje
        const valores =data.operacion.split("%");//se separa por el porcentaje y se obtienen los dos valores
        resultado = eval(`${valores[0]} * (${valores[1]} / 100)`);//se realiza la operación en la cadena
      }else{//si no 
        resultado = eval(data.operacion);
      }
      //se actualiza setData resultado con la variable resultado
      //se actualiza setData operacion para que si hay un resultado se puedan seguir haciendo operaciones
      setData({
        ...data,
        resultado,operacion:""
      });
    } catch (error) {
      //el mensaje que dará si hay un error Ej: 8*9+= Error
      setData({
        ...data,
        operacion: "Error",
      });
    }
  };
  return (
    <main>
      <span className="resultado">{data.resultado}</span>
      <span className="display">{data.operacion}</span>
      {/**parametros que pasa al componente "Boton" */}
      <Boton texto="C" clase="gris" handleClick={limpiar} />
      {/**cambia de positivo a negativo o viceversa */}
      <Boton texto="+/-" clase="gris" handleClick={escritura} />
      <Boton texto="%" clase="gris" handleClick={escritura} />
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
      <Boton texto="." clase="numero" handleClick={escritura} />
      {/**Cuando hace click en un boton ejecuta la funcion escritura */}
      <Boton texto="0" clase="numero" handleClick={escritura} />
      <Boton texto="<-" clase="numero" handleClick={eliminar} />
      <Boton texto="=" clase="operacion" handleClick={resultadoOperacion} />
    </main>
  );
};
export default Calculadora;
