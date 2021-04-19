CREATE PROCEDURE [dbo].[ObterTotalizadoresPorMes]
	@Ano int,
	@Mes int
AS
	SELECT	l.Conta, SUM(l.Valor) as Valor
	FROM	Lancamentos as l
	WHERE	MONTH(l.[Data]) = @Mes
	AND		YEAR(l.[Data]) = @Ano
	GROUP BY l.Conta