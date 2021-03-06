﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hotel.BIZ;
using Hotel.COMMON.Interfaces;
using Hotel.DAL;
using Hotel.COMMON.Entidades;
using Microsoft.Win32;
using System.IO;

namespace Hotel.GUI.Registros
{
    /// <summary>
    /// Lógica de interacción para MenuO.xaml
    /// </summary>
    public partial class MenuO : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorTipoHabitacion manejadorTipoHabitacion;
        IManejadorCaracteristicas manejadorCaracteristicas;
        IManejadorRegistroHabitacion manejadorRegistroHabitacion;
        IManejadorOtroServicio manejadorOtroServicio;
        IManejadorContraseñaRegistro manejadorContraseñaRegistro;
        accion accionTipoHabitacion;
        accion accionCaracteristicas;
        accion accionRegistro;
        accion accionOtro;
        accion accionContaseña;
        int x;

        public MenuO()
        {
            InitializeComponent();
            manejadorTipoHabitacion = new ManejadorTipoHabitacion(new RepositorioGenerico<TipoHabitaciones>());
            manejadorCaracteristicas = new ManejadorCaracteristicasH(new RepositorioGenerico<CaracteristicasHabitacion>());
            manejadorRegistroHabitacion = new ManejadorRegistroHabitacion(new RepositorioGenerico<RegistroHabitacion>());
            manejadorOtroServicio = new ManejadorOtrosServicios(new RepositorioGenerico<OtrosServicios>());
            manejadorContraseñaRegistro = new ManejadorContraseñaRegistro(new RepositorioGenerico<ContraseñaRegistro>());
            HabilitarCajasTipoHabitacion(false);
            HabilitarCajasCaracteristicasHabitacion(false);
            HabilitarCajasRegistroHabitacion(false);
            HabilitarCajasOtrosServicios(false);
            HabilitarCajasUsuario(false);
            HabilitarBotonesTipoHabitacion(true);
            HabilitarBotonesCaracteristicasHabitacion(true);
            HabilitarBotonesRegistroHabitacion(true);
            HabilitarBotonesOtrosServicios(true);
            HabilitarBotonesUsuario(true);
            ActualizarTabla();
        }

        private void HabilitarBotonesUsuario(bool habilitados)
        {
            btnNuevo4.IsEnabled = habilitados;
            btnGuardar4.IsEnabled = !habilitados;
            btnCancelar4.IsEnabled = !habilitados;
        }

        private void HabilitarBotonesOtrosServicios(bool habilitados)
        {
            btnNuevo3.IsEnabled = habilitados;
            btnEditar3.IsEnabled = habilitados;
            btnEliminar3.IsEnabled = habilitados;
            btnGuardar3.IsEnabled = !habilitados;
            btnCancelar3.IsEnabled = !habilitados;
            btnCargarFotoServicio.IsEnabled = !habilitados;
        }

        private void HabilitarBotonesRegistroHabitacion(bool habilitados)
        {
            btnNuevo2.IsEnabled = habilitados;
            btnEditar2.IsEnabled = habilitados;
            btnEliminar2.IsEnabled = habilitados;
            btnGuardar2.IsEnabled = !habilitados;
            btnCancelar2.IsEnabled = !habilitados;
        }

        private void HabilitarBotonesCaracteristicasHabitacion(bool habilitados)
        {
            btnNuevo1.IsEnabled = habilitados;
            btnEditar1.IsEnabled = habilitados;
            btnEliminar1.IsEnabled = habilitados;
            btnGuardar1.IsEnabled = !habilitados;
            btnCancelar1.IsEnabled = !habilitados;
        }

        private void HabilitarBotonesTipoHabitacion(bool habilitados)
        {
            btnNuevo.IsEnabled = habilitados;
            btnEditar.IsEnabled = habilitados;
            btnEliminar.IsEnabled = habilitados;
            btnGuardar.IsEnabled = !habilitados;
            btnCancelar.IsEnabled = !habilitados;
            btnCargarFoto.IsEnabled = !habilitados;

        }

        private void HabilitarCajasUsuario(bool habilitadas)
        {
            txbUsuario.Clear();
            txbUsuario.IsEnabled = habilitadas;
            txbContraseña.Clear();
            txbContraseña.IsEnabled = habilitadas;
            txbContraseñaR.Clear();
            txbContraseñaR.IsEnabled = habilitadas;
        }

        private void HabilitarCajasOtrosServicios(bool habilitadas)
        {
            txbNombreServicio.Clear();
            txbNombreServicio.IsEnabled = habilitadas;
            txbDescripcion.Clear();
            txbDescripcion.IsEnabled = habilitadas;
        }

        private void HabilitarCajasRegistroHabitacion(bool habilitadas)
        {
            txbNombreHabitacion.Clear();
            txbNombreHabitacion.IsEnabled = habilitadas;
            cmbTipoHabitacionRegistro.IsEnabled = habilitadas;
            cmbTipoHabitacionRegistro.ItemsSource = null;
            cmbTipoHabitacionRegistro.ItemsSource = manejadorTipoHabitacion.Listar;
        }

        private void HabilitarCajasCaracteristicasHabitacion(bool habilitadas)
        {
            txbNBaños.Clear();
            txbNBaños.IsEnabled = habilitadas;
            txbNCamas.Clear();
            txbNCamas.IsEnabled = habilitadas;
            cmbTipoHabitacionCarcteristicas.IsEnabled = habilitadas;
            cmbTipoHabitacionCarcteristicas.ItemsSource = null;
            cmbTipoHabitacionCarcteristicas.ItemsSource = manejadorTipoHabitacion.Listar;
        }

        private void HabilitarCajasTipoHabitacion(bool habilitadas)
        {
            txbTipoHabitacion.Clear();
            txbTipoHabitacion.IsEnabled = habilitadas;
            txbCostoHabitacion.Clear();
            txbCostoHabitacion.IsEnabled = habilitadas;
        }

        private void ActualizarTabla()
        {
            lsvTipoHabitacion.ItemsSource = null;
            lsvTipoHabitacion.ItemsSource = manejadorTipoHabitacion.Listar;
            dtgTipoHabitacionCaracteristicas.ItemsSource = null;
            dtgTipoHabitacionCaracteristicas.ItemsSource = manejadorCaracteristicas.Listar;
            dtgTipoHabitacionRegistro.ItemsSource = null;
            dtgTipoHabitacionRegistro.ItemsSource = manejadorRegistroHabitacion.Listar;
            dtgOtrosServicios.ItemsSource = null;
            dtgOtrosServicios.ItemsSource = manejadorOtroServicio.Listar;
        }


        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasTipoHabitacion(true);
            HabilitarBotonesTipoHabitacion(false);
            accionTipoHabitacion = accion.Nuevo;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            TipoHabitaciones pro = lsvTipoHabitacion.SelectedItem as TipoHabitaciones;
            if (pro != null)
            {
                HabilitarCajasTipoHabitacion(true);
                txbTipoHabitacion.Text = pro.NombtreTipoH;
                txbCostoHabitacion.Text = pro.CostoHabitacion;
                imgFoto.Source = ByteToImage(pro.Fotografia);
                accionTipoHabitacion = accion.Editar;
                HabilitarBotonesTipoHabitacion(false);
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de habitacion que desea editar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private ImageSource ByteToImage(byte[] fotografia)
        {
            if (fotografia==null)
            {
                return null;
            }
            else
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(fotografia);
                biImg.BeginInit();
                biImg.StreamSource=ms;
                biImg.EndInit();
                ImageSource imgSrc = biImg as ImageSource;
                return imgSrc;
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasTipoHabitacion(false);
            HabilitarBotonesTipoHabitacion(true);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            TipoHabitaciones pro = lsvTipoHabitacion.SelectedItem as TipoHabitaciones;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este tipo de habitación?", "Habitaciones", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorTipoHabitacion.Eliminar(pro.Id))
                    {
                        MessageBox.Show("El tipo de habitación ha sido eliminado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El tipo de habitacion no se pudo eliminar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txbTipoHabitacion.Text !="" && imgFoto!=null) {
                if (int.TryParse(txbCostoHabitacion.Text, out x) && !int.TryParse(txbTipoHabitacion.Text, out x)) {
                    if (accionTipoHabitacion == accion.Nuevo)
                    {
                        TipoHabitaciones pro = new TipoHabitaciones()
                        {
                            NombtreTipoH = txbTipoHabitacion.Text,
                            CostoHabitacion = txbCostoHabitacion.Text,
                            Fotografia = ImageToByte(imgFoto.Source),
                        };
                        if (manejadorTipoHabitacion.Agregar(pro))
                        {
                            MessageBox.Show("El tipo de habitación fue agregado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesTipoHabitacion(true);
                            HabilitarCajasTipoHabitacion(false);
                        }
                        else
                        {
                            MessageBox.Show("El tipo de habitación no se pudo agregar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        TipoHabitaciones pro = lsvTipoHabitacion.SelectedItem as TipoHabitaciones;
                        pro.NombtreTipoH = txbTipoHabitacion.Text;
                        pro.CostoHabitacion = txbCostoHabitacion.Text;
                        if (manejadorTipoHabitacion.Modificar(pro))
                        {
                            MessageBox.Show("Tipo de habitación modificado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesTipoHabitacion(true);
                            HabilitarCajasTipoHabitacion(false);
                        }
                        else
                        {
                            MessageBox.Show("El tipo de habitacion no se pudo actualizar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo de costo no es de tipo numerico o el campo de tipo de habitacion no admite números", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan campos por rellenar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private byte[] ImageToByte(ImageSource image)
        {
            if (image!=null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memStream);
                return memStream.ToArray();
            }
            else
            {
                return null;
            }
        }

        private void btnNuevo1_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasCaracteristicasHabitacion(true);
            HabilitarBotonesCaracteristicasHabitacion(false);
            accionCaracteristicas = accion.Nuevo;
        }

        private void btnEditar1_Click(object sender, RoutedEventArgs e)
        {
            CaracteristicasHabitacion pro = dtgTipoHabitacionCaracteristicas.SelectedItem as CaracteristicasHabitacion;
            if (pro != null)
            {
                HabilitarCajasCaracteristicasHabitacion(true);
                txbNCamas.Text = pro.NCamas;
                txbNBaños.Text = pro.NBaños;
                cmbTipoHabitacionCarcteristicas.Text = pro.TipoHabitacion;
                accionCaracteristicas = accion.Editar;
                HabilitarBotonesCaracteristicasHabitacion(false);
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de habitacion que desea editar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void btnGuardar1_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoHabitacionCarcteristicas.Text!="" && txbNBaños.Text!="" && txbNCamas.Text!="") {
                if (int.TryParse(txbNBaños.Text, out x) && int.TryParse(txbNCamas.Text, out x))
                {
                    if (accionCaracteristicas == accion.Nuevo)
                {
                    
                        CaracteristicasHabitacion pro = new CaracteristicasHabitacion()
                        {
                            TipoHabitacion = cmbTipoHabitacionCarcteristicas.Text,
                            NBaños = txbNBaños.Text,
                            NCamas = txbNCamas.Text,
                        };
                        if (manejadorCaracteristicas.Agregar(pro))
                        {
                            MessageBox.Show("Las caracteristicas de habitación fue agregado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesCaracteristicasHabitacion(true);
                            HabilitarCajasCaracteristicasHabitacion(false);
                        }
                        else
                        {
                            MessageBox.Show("Las caracteristicas de habitación no se pudo agregar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    
                }
                else
                {
                    CaracteristicasHabitacion pro = dtgTipoHabitacionCaracteristicas.SelectedItem as CaracteristicasHabitacion;
                    pro.TipoHabitacion = cmbTipoHabitacionCarcteristicas.Text;
                    pro.NCamas = txbNCamas.Text;
                    pro.NBaños = txbNCamas.Text;
                    if (manejadorCaracteristicas.Modificar(pro))
                    {
                        MessageBox.Show("Caracteristica de habitación modificado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                        HabilitarBotonesCaracteristicasHabitacion(true);
                        HabilitarCajasCaracteristicasHabitacion(false);
                    }
                    else
                    {
                        MessageBox.Show("La caracteristica de habitacion no se pudo actualizar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                }
                else
                {
                    MessageBox.Show("El campo numero de baños o de camas no es de tipo numerico", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan Campos por rellenar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar1_Click(object sender, RoutedEventArgs e)
        {
            CaracteristicasHabitacion pro = dtgTipoHabitacionCaracteristicas.SelectedItem as CaracteristicasHabitacion;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar estas Caracteristicas de habitación?", "Habitaciones", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorCaracteristicas.Eliminar(pro.Id))
                    {
                        MessageBox.Show("Las caracteristicas de habitación ha sido eliminado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("Las caracteristicas de habitacion no se pudo eliminar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void btnCancelar1_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasCaracteristicasHabitacion(false);
            HabilitarBotonesCaracteristicasHabitacion(true);
        }

        private void btnNuevo2_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasRegistroHabitacion(true);
            HabilitarBotonesRegistroHabitacion(false);
            accionRegistro = accion.Nuevo;
        }

        private void btnEditar2_Click(object sender, RoutedEventArgs e)
        {
            RegistroHabitacion pro = dtgTipoHabitacionRegistro.SelectedItem as RegistroHabitacion;
            if (pro != null)
            {
                HabilitarCajasRegistroHabitacion(true);
                cmbTipoHabitacionRegistro.Text = pro.TipoHabitacion;
                txbNombreHabitacion.Text = pro.NombreHabitacion;
                accionRegistro = accion.Editar;
                HabilitarBotonesRegistroHabitacion(false);
            }
            else
            {
                MessageBox.Show("Seleccione la habitacion que desea editar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void btnGuardar2_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoHabitacionRegistro.Text!="" && txbNombreHabitacion.Text!="") {
                if (accionRegistro == accion.Nuevo)
                {
                    RegistroHabitacion pro = new RegistroHabitacion()
                    {
                        TipoHabitacion = cmbTipoHabitacionRegistro.Text,
                        NombreHabitacion = txbNombreHabitacion.Text,
                    };
                    if (manejadorRegistroHabitacion.Agregar(pro))
                    {
                        MessageBox.Show("La habitación fue agregado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                        HabilitarBotonesRegistroHabitacion(true);
                        HabilitarCajasRegistroHabitacion(false);
                    }
                    else
                    {
                        MessageBox.Show("La habitación no se pudo agregar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    RegistroHabitacion pro = dtgTipoHabitacionRegistro.SelectedItem as RegistroHabitacion;
                    pro.TipoHabitacion = cmbTipoHabitacionRegistro.Text;
                    pro.NombreHabitacion = txbNombreHabitacion.Text;
                    if (manejadorRegistroHabitacion.Modificar(pro))
                    {
                        MessageBox.Show("Habitación modificado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                        HabilitarBotonesRegistroHabitacion(true);
                        HabilitarCajasRegistroHabitacion(false);
                    }
                    else
                    {
                        MessageBox.Show("Habitación no se pudo actualizar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan Campos por rellenar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar2_Click(object sender, RoutedEventArgs e)
        {
            RegistroHabitacion pro = dtgTipoHabitacionRegistro.SelectedItem as RegistroHabitacion;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar estas habitación?", "Habitaciones", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorRegistroHabitacion.Eliminar(pro.Id))
                    {
                        MessageBox.Show("La abitación ha sido eliminado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("La habitacion no se pudo eliminar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasRegistroHabitacion(false);
            HabilitarBotonesRegistroHabitacion(true);
        }

        private void btnNuevo3_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasOtrosServicios(true);
            HabilitarBotonesOtrosServicios(false);
            accionOtro = accion.Nuevo;
        }

        private void btnEditar3_Click(object sender, RoutedEventArgs e)
        {
            OtrosServicios pro = dtgOtrosServicios.SelectedItem as OtrosServicios;
            if (pro != null)
            {
                HabilitarCajasOtrosServicios(true);
               txbNombreServicio.Text = pro.NombreServicio;
                txbDescripcion.Text = pro.Descripcion;
                imgFotoServicio.Source = ByteToImage(pro.FotografiaServicio);
                accionOtro = accion.Editar;
                HabilitarBotonesOtrosServicios(false);
            }
            else
            {
                MessageBox.Show("Seleccione el servicio que desea editar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void btnGuardar3_Click(object sender, RoutedEventArgs e)
        {
            if (txbNombreServicio.Text!="" && txbDescripcion.Text!="") {
                if (!int.TryParse(txbNombreServicio.Text, out x) && !int.TryParse(txbDescripcion.Text, out x)) {
                    if (accionOtro == accion.Nuevo)
                    {
                        OtrosServicios pro = new OtrosServicios()
                        {
                            NombreServicio = txbNombreServicio.Text,
                            Descripcion = txbDescripcion.Text,
                            FotografiaServicio = ImageToByte(imgFotoServicio.Source),
                        };
                        if (manejadorOtroServicio.Agregar(pro))
                        {
                            MessageBox.Show("El servicio fue agregado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesOtrosServicios(true);
                            HabilitarCajasOtrosServicios(false);
                        }
                        else
                        {
                            MessageBox.Show("El servicio no se pudo agregar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        OtrosServicios pro = dtgOtrosServicios.SelectedItem as OtrosServicios;
                        pro.NombreServicio = txbNombreServicio.Text;
                        pro.Descripcion = txbDescripcion.Text;
                        if (manejadorOtroServicio.Modificar(pro))
                        {
                            MessageBox.Show("Servicio modificado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesOtrosServicios(true);
                            HabilitarCajasOtrosServicios(false);
                        }
                        else
                        {
                            MessageBox.Show("El servicio no se pudo actualizar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("El campo del Nombre del servicio o la descripcion no acptan ese tipo de caracteres", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan Campos por rellenar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar3_Click(object sender, RoutedEventArgs e)
        {
            OtrosServicios pro = dtgOtrosServicios.SelectedItem as OtrosServicios;
            if (pro != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este servicio?", "Habitaciones", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorOtroServicio.Eliminar(pro.Id))
                    {
                        MessageBox.Show("El servicion ha sido eliminado correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El servicio no se pudo eliminar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }
        }

        private void btnCancelar3_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasOtrosServicios(false);
            HabilitarBotonesOtrosServicios(true);
        }

        private void btnNuevo4_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasUsuario(true);
            HabilitarBotonesUsuario(false);
            accionContaseña = accion.Nuevo;
        }

        private void btnGuardar4_Click(object sender, RoutedEventArgs e)
        {
            if (txbUsuario.Text!="" && txbContraseña.Password!="" && txbContraseñaR.Password!="") {
                if (txbContraseña.Password == txbContraseñaR.Password) {
                    if (accionContaseña == accion.Nuevo)
                    {
                        ContraseñaRegistro pro = new ContraseñaRegistro()
                        {
                            Usuario = txbUsuario.Text,
                            Contraseña = txbContraseña.Password,
                        };
                        if (manejadorContraseñaRegistro.Agregar(pro))
                        {
                            MessageBox.Show("Usuario Agregado Correctamente", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                            HabilitarBotonesUsuario(true);
                            HabilitarCajasUsuario(false);
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se puede agregar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña no coincide intente de nuevo", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Aun le faltan Campos por rellenar", "Habitaciones", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelar4_Click(object sender, RoutedEventArgs e)
        {
            HabilitarCajasUsuario(false);
            HabilitarBotonesUsuario(true);
        }

        private void Regresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ir = new MainWindow();
            ir.Show();
            this.Close();
        }

        private void btnCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Seleccione una foto";
            dialogo.Filter = "Archivos de imagen|*.jpg;*.png;*.gif";
            if (dialogo.ShowDialog().Value)
            {
                imgFoto.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }

        private void btnCargarFotoServicio_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "Seleccione una foto";
            dialogo.Filter = "Archivos de imagen|*.jpg;*.png;*.gif";
            if (dialogo.ShowDialog().Value)
            {
                imgFotoServicio.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }
        
    }
}
