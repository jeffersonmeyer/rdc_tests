CREATE PROCEDURE [dbo].[ObterLancamentosPorMes]
	@Ano int,
	@Mes int
AS
	SELECT	*
	FROM	Lancamentos	as l
	WHERE	MONTH(l.[Data]) = @Mes
	AND		YEAR(l.[Data]) = @Ano
	ORDER BY l.[Data]