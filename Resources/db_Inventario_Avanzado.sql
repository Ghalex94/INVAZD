create database db_inventario_avanzado;
use db_inventario_avanzado;


-- Creacion de la tabla producto:
create table tb_presentacion(
	id_presentacion 	int auto_increment primary key, -- COdigo de la Presentacion
    
    presentacion 		varchar(30) -- Detalle de la presentacion
);

create table tb_producto(
	id_prod 			int auto_increment primary key, -- codigo del producto
    id_presentacion		int, -- Llave foranea de la TABLA TB_PRESENTACION
    
    cod_bar 			varchar(50), -- Codigo de Barra
	producto 			varchar(200), -- Nombre del producto
    det_prod 			varchar(200), -- Detalle del producto
    cant_total			float, -- cantidad total del producto
    fecha_vencimiento 	date, -- Fecha de vencimiento POSIBLE PARA TODOS
    lote 				varchar(50), -- Lote del producto PARA FARMACIA
    laboratorio 		varchar(50), -- Nombre del laboratorio PARA FARMACIA	
    composicion 		varchar(100), -- COmponenetes que tiene el medicamento SOLO PARA FARMACIA
    estado				tinyint, -- Estados que tendra el producto: Habilidato y Deshabilitado
    foreign key (id_presentacion) references tb_presentacion(id_presentacion) -- Llave foranea
);

create table tb_distribuidor(
	id_dist 			int  auto_increment primary key, -- Codigo del Distribuidor
    
    nom_distri			varchar(100), -- Nombre del Distribuidor
    ruc_distri			varchar(11), -- RUC del Distribuidor Guiño Guiño
    tiempo_espera		int, -- Tiempo de esperas en DIAS para realizar el pago
    direccion1			varchar(100), -- Primera  direccion del distribuidor
    direccion2			varchar(100), -- Segunda  direccion del distribuidor
    telef1				varchar(9), -- Primer telefono del distribuidor
    telef2				varchar(9), -- Segundo telefono del distribuidor
    contacto			varchar(50), -- Nombre del contacto del distribuidor
    telef_contacto		varchar(9), -- Numero del contacto del distibuidor
    estado				tinyint -- Estado del Distribuidor: Habilitado, Deshabilitado
);

create table tb_moneda(
	id_moneda 			int auto_increment primary key, -- Codigo de la moneda
    
    moneda				varchar(20), -- Nombre de la moneda
    simbolo				varchar(5), -- Simbolo de la moneda
    tc_referencial		float,	-- tipo_cambio_referencial
    estado				tinyint -- Estado de la moneda, Habilitado o Deshabilitado
);

create table tb_compra_ingreso(
	id_com_ing			int auto_increment primary key, -- Codigo de Compra Ingreso	
    id_dist				int, -- Clave foranea de la Tabla tb_distribuidor
    id_moneda			int, -- Clave foranea de la Tabla tb_moneda
    
    n_serie_compr		varchar(15),	-- Numero de serioe del comprobante
    precio_compr_soles	float, -- Precion Compra en Soles
    precio_Compr_otros	float, -- Precio Compra en Otra Moneda
    tc_compra			float, -- TIpo de cambio del momento de Hacer la Compra			
    fecha_ingreso		date, -- Fecha de ingreso de la compra
    nota				varchar(100), -- Descripcion de la compra de ingreso
    estado				tinyint, -- Estado de la compra: Pagado y No Pagado
    foreign key(id_dist) references tb_distribuidor(id_dist), -- Llave foranea
    foreign key(id_moneda) references tb_moneda(id_moneda) -- Llave foranea
);

create table tb_compra_detalle(
	id_com_ing			int, -- Codigo de Compra Ingreso // Clave foranea de la Tabla tb_compra_Ingreso
    id_prod				int, -- Codigo de Producto // Clave foranea de la Tabla tb_producto
    
	cantidad			float, -- Cantidad de la compra Detalle
    precio_compra		float, -- ¨Precio Compra de la Compra Detalle
    precio_venta		float, -- Precio Venta de la compra Detalle
    primary key(id_com_ing,id_prod),
    foreign key(id_com_ing) references tb_compra_ingreso(id_com_ing),
    foreign key(id_prod) references tb_producto(id_prod)
);

create table tb_pagos_productos(
	id_com_ing			int primary key, -- Codigo de Pagos Productos /// Clave foranea de la Tabla tb_compra_ingreso
    
    compra_total		float, -- Compra Total de pagos Productos
    saldo				float, -- Saldo por pagar
    acuenta			float, -- A cuenta
    fecha_vencimiento	date, -- Fecha a vencer para el pago
    foreign key (id_com_ing) references tb_compra_ingreso(id_com_ing) -- Llave foranea
);

create table tb_pagos_detalle(
	id_pago_detalle		int auto_increment primary key, -- Codigo de pagos Detalle
    id_com_ing 			int, -- Clave foranea de la Tabla tb_pagos_productos
    id_moneda			int, -- Clave foranea de la Tabla tb_moneda
    
    monto				float, -- Es el dinero que se va a sumar a cuenta
    caja_origen			int, -- Caja de donde se retire el dinero para realizar el pago
    origen_pago			int, -- Lugar de donde se retiro el dinero (Efectivo, tarjetas, bitcoin, etc)
    fecha_pago			date, -- Fecha de pago a cuenta
    t_cambio			float, -- Tipo de Cambio
    foreign key(id_com_ing) references tb_pagos_productos(id_com_ing),
    foreign key(id_moneda) references tb_moneda(id_moneda)
);

create table tb_cliente(
	id_cli				int auto_increment primary key, -- Codigo de Cliente
    
    dni_cli				char(8), -- DNI del Cliente
    nom_cli				varchar(100), -- Nombre Completo del Cliente
    ape_cli				varchar(100), -- Apellido Completo del Cliente
    ruc_cli				varchar(11), -- RUC del Cliente
    raz_soc				varchar(150), -- Razon social del Cliente
    dir_cli				varchar(150), -- Direccion del Cliente
    telf_cel			varchar(9), -- Telefono o Celular del Cliente
    fec_nac				date, -- Decha de Nacimineto del Cliente
    correo				varchar(50), -- Correo del Cliente
    tipo				tinyint -- Tipo de Persona: Juridica o Natural
);

create table tb_usuario(
	id_usu				int auto_increment primary key, -- COdigo del usuario
    
    nombre_usu			varchar(150), -- Nombre completo del usuario
    usu					varchar(30), -- Usuario
    contra				varchar(30), -- Contraseña
    tipo				tinyint, -- Tipo de Usuario
    permisos			varchar(50) -- 1,2,3,4
);

create table tb_ventas_cotizaciones(
	id_ven_cot 			int auto_increment primary key, -- COdigo de Ventas Cotizaciones
    id_cli				int, -- Clave Foranea de la Tabla tb_cliente
    id_usu				int, -- Clave Foranea de la Tabla tb_usuario
    id_moneda			int, -- Clave Forenea de la Tabla tb_moneda
    
    fecha				date, -- Fecha en la que se hizo la cotizacionn
    total_compra		float, -- El total de la compra de Ventas y Cotizaciones
    tola_venta			float, -- El total de la venta de Ventas y Cotizaciones
    ganancia			float, -- la ganancia de la venta
    descuento			float, -- Descuento echo en la venta
    estado				tinyint, -- Tipo de venta: Venta anulada, Venta modificada, Venta de solo cotizacio
    t_Cambio			float, -- Tipo de Cambio
    foreign key(id_cli) references tb_cliente(id_cli),
    foreign key(id_usu) references tb_usuario(id_usu),
    foreign key(id_moneda) references tb_moneda(id_moneda)
);

create table tb_venta_detalle(
	id_ven_det 			int auto_increment primary key, -- Codigo de Venta Detalle
    id_ven_cot			int, -- Clave Foranea de la Tabla tb_ventas_cotizaciones
    id_prod				int, -- Clave foranea de la Tabla tb_producto
    id_com_ing			int, -- Clave Foranea de la Tabla tb_compra_detalle
    
    pre_ori				float, -- Precio Origen
    pre_tot_ori			float, -- Precio total de Origen
    pre_final			float, -- Precio final
    pre_tot_final		float, -- Precio total final,
    cant				float, -- Cantidad
    serie				varchar(50), -- Nserie del producto
    foreign key(id_ven_cot) references tb_ventas_cotizaciones(id_ven_cot),
    foreign key(id_prod) references tb_producto(id_prod),
    foreign key(id_com_ing) references tb_compra_detalle(id_com_ing)
);

create table tb_caja_chica(
	id_caja_chica		int auto_increment primary key, -- COdigo de la CajaChica
    m_abrir				float, -- Monto Abrir
    m_total				float, -- Monto Total
    m_cerrar			float, -- Monto Cerrar
    m_dejado			float, -- Monto Dejado
    m_retirado			float, -- Monto Retirado
    fech_ini			datetime, -- Fecha inicio
    fech_fin			datetime, -- Fecha en que termino
    estado				tinyint, -- Estado de la caja CHica
    nroCaja				int, -- El numero de la caja
    usuario_a			varchar(30), -- El usuario al que abrio la caja
    usuario_c			varchar(30) -- El usuario al que cerror la caja
);

create table tb_tipo(
	id_tipo 			int auto_increment primary key, -- Codigo de tipo
    tipo				varchar(45) -- Detalle Tipo
);

create table tb_tipo_pago(
	id_tipo_pago		int auto_increment primary key, -- Codigo de tipo de pago
    id_caja_chica 		int, -- Clave foranea de la Tabla tb_caja_chica
    id_tipo				int, -- Clave Foranea de la Tabla tb_tipo
    id_moneda			int, -- Clave Foranea de la Tabla tb_moneda
    
    monto				float, -- Monto de tipo de pago
    t_cambio			float, -- Tipo de cambio
    foreign key (id_caja_chica) references tb_caja_chica(id_caja_chica),
    foreign key (id_tipo) references tb_tipo(id_tipo),
    foreign key (id_moneda) references tb_moneda(id_moneda)
);

create table tb_caja_grande(
	id_caja_grande		int auto_increment primary key, -- Codigo de la caja Grande
    id_caja_chica		int, -- cLave Foranea de la Tabla tb_caja_chica
    
    nro_caja			int, -- Numero de la Caja Grande
    monto				float, -- Monto de la caja grande
    foreign key (id_caja_chica) references tb_caja_chica(id_caja_chica)
);
