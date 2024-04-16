import React from "react";
import "./boton.css";
//el boton va a recibir parametros
const Boton = (params) => {
  const { texto, clase, handleClick } = params; //parametros que recibe
  //tendra la clase que recibe por parametro y el texto que vien por parametro 
  //ademas recibe la funcion para hacer click 
  return <button className={clase} onClick={handleClick}>{texto}</button>;
};
export default Boton;
