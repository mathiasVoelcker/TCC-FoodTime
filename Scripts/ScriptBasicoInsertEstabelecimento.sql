select * from schemaFoodTime.estabelecimento;
select * from schemaFoodTime.endereco;

insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 5.0, 5.0);

insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('teste', 'test', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 1.5, 1);