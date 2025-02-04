import { createTheme } from "@mui/material/styles";

export const theme = createTheme({
  palette: {
    primary: {
      main: "#1976d2", // Azul padrão do MUI, pode customizar
    },
    secondary: {
      main: "#ff9800",
    },
    background: {
      default: "#f5f5f5",
    },
  },
  typography: {
    fontFamily: "Roboto, sans-serif",
  },
});
