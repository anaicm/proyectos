//componente para cambiar de claro a oscuro
import { useEffect, useState } from "react";
import "./switch.css";
//el boton va a recibir parametros
const Switch = () => {
    const [theme, setTheme]=useState('claro');//primero esta claro
    //si hace click en onChange lo cambia al contrario
    //si es verdadero me lo pones oscuro y si es falso lo pones claro
    const handleChange =(e)=>setTheme(e.target.checked ? 'oscuro' : 'claro');
    //cuando se dispare el useEffect va a agregar la propiedad o la va a quitar 
    useEffect(()=>{
        //theme => tendra el valor de la constate en ese momento del codigo
        //"data-theme" => es la clase para cambiar el color de las variables
        document.body.setAttribute("data-theme",theme)
    },[theme])
  return (
  <section className="switch">
    <label className="toggle">
        <input type="checkbox" className="check-switch" onChange={handleChange} hidden/>{/**hidden para que este oculto */}
        <span className="slider"/>
    </label>

  </section>
  ) 
};
export default Switch;
