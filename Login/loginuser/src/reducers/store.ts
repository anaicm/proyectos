//importaciones de la libreria 
import { configureStore } from '@reduxjs/toolkit';
import { useDispatch, useSelector } from 'react-redux';

import appSlice from './appSlice.ts';

export const store = configureStore({
    reducer: {
        app: appSlice.reducer,
      
    }
});

type rootStateType = ReturnType<typeof store.getState>

type mapStateType = ReturnType<typeof appSlice.reducer>

export const useAppDispatch = () => useDispatch<typeof store.dispatch>();

export const useAppSelector = () => useSelector<rootStateType, mapStateType>(a => a.app);
