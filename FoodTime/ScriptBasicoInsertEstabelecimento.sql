select * from schemaFoodTime.estabelecimento;
select * from schemaFoodTime.endereco;
select * from schemaFoodTime.estabelecimento_preferencia;

insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 5.0, 5.0);
insert into schemaFoodTime.endereco
values ('teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 'teste', 1.0, 1.0);

insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('teste', 'test', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 1.5, 1);
insert into schemaFoodTime.estabelecimento (nome, telefone, horarioAbertura, horarioFechamento, precoMedio, id_endereco)
values ('Super Restaurante', '92929832', CURRENT_TIMESTAMP , CURRENT_TIMESTAMP, 65.2, 2);

insert into schemaFoodTime.usuario (email, senha, nome, sobrenome, dataNascimento, fotoPerfil, admin)
values ('teste', 'test', 'test', 'test', CURRENT_TIMESTAMP, 'test', 1);
insert into schemaFoodTime.usuario (email, senha, nome, sobrenome, dataNascimento, fotoPerfil, admin)
values ('teste1', 'teste1', 'teste1', 'teste1', CURRENT_TIMESTAMP, 'teste1', 0);

select pref.descricao
from schemaFoodTime.preferencia pref inner JOIN
schemaFoodTime.estabelecimento_preferencia ep 
on pref.id = ep.id_preferencia
where ep.id_estabelecimento = 1;


drop table schemaFoodTime.endereco;
