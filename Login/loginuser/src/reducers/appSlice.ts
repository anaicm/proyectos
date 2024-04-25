import { createSlice } from "@reduxjs/toolkit";

//AppState => le pongo este tipo (nombre que yo quiero) para la app
interface AppState {

  email:string;
  password:string;
}
const initialState: AppState = {
  email:"",
  password:"",
};
const appSlice = createSlice({
  //app => le pongo de nombre app para el componente (es el nombre generico)
  name: "app",
  initialState,
  reducers: {
    setEmail: (state, action) => {
      state.email = action.payload;
    },
    setPassword: (state, action) => {
      state.password = action.payload;
    },
  },
});

export default appSlice;
