import React, { useState } from "react";
import "./formLogin.css";
//archivos para redux
import { useAppDispatch, useAppSelector } from "../reducers/store.ts";
import appSlice from "../reducers/appSlice.ts";

function FormLogin() {
   //hace falta si o si para redux
   const appState = useAppSelector(); //
   const dispatch = useAppDispatch(); //
  

  // Funciones para manejar cambios en los campos de entrada, guarda el valor del email que entra
  //por pantalla
  const handleEmailChange = (e) => {
    dispatch(appSlice.actions.setEmail(e.target.value));
  };
// guarda el valor del password que entra por pantalla
  const handlePasswordChange = (e) => {
    dispatch(appSlice.actions.setPassword(e.target.value));
  };

  // Función para manejar el envío del formulario, 
  const handleSubmit = (e) => {
    e.preventDefault(); // Prevenir el envío del formulario por defecto
    // Aquí puedes hacer algo con los valores de email y passwor
    //aqui se realizaria el código para enviar los datos a redux
    console.log("Correo electrónico:", appState.email);//appState.email esta leyendo desde appSlice
    console.log("Contraseña:", appState.password);
  };
  return (
    <>
      <div className="main">
        <div className="containerFlex">
          <div className="container">
          <input
              type="text"
              placeholder="Correo electrónico"
              value={appState.email}
              onChange={handleEmailChange}
            />
            <input
              type="password"
              placeholder="Contraseña"
              value={appState.password}
              onChange={handlePasswordChange}
            />
            <button type="submit" onClick={handleSubmit}>Aceptar</button>
            <button>NuevoUsuario</button>
          </div>
        </div>
      </div>
    </>
  );
}

export default FormLogin;
