import { createSlice } from "@reduxjs/toolkit";

//AppState => le pongo este tipo (nombre que yo quiero) para la app
interface AppState {
  data:{ operacion: "", resultado: "" };
}
const initialState: AppState = {
  data: { operacion: "", resultado: "" },
};
const appSlice = createSlice({
  //app => le pongo de nombre app para el componente (es el nombre generico)
  name: "app",
  initialState,
  reducers: {
    setData: (state, action) => {
      state.data = action.payload;
    },
  },
});

export default appSlice;
