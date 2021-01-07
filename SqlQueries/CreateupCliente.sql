create procedure upCliente
as 
begin
SET NOCOUNT ON;
(
	select 
		c.IdCliente,
		c.Nombre,
		c.Apellidos,
		c.Direccion
	from 
		clientes c
	join
	(select top (1)
		r.IdCliente, 
		count(r.fecha) as NumeroCompras
	from 
		RelClienteTienda r
	group by
		r.IdCliente) tabla
	on
		tabla.IdCliente=c.IdCliente
)
end
go