CREATE PROCEDURE [dbo].[InserirLancamento]
	@Data DATETIME,
	@Valor NUMERIC(18,10),
	@Descricao VARCHAR(250),
	@Conta VARCHAR(50),
	@Tipo CHAR(1)
AS
BEGIN
	INSERT INTO Lancamentos([Data], [Valor], [Descricao], [Conta], [Tipo])
	VALUES (@Data, @Valor, @Descricao, @Conta, @Tipo)

	SELECT @@IDENTITY
END

