INSERT INTO Usuario (nomeUsuario,login,senha) 
    values ('Eduardo','duuhsousa','BACON'),
        ('Roberta','robertinha','454545'),
        ('Wagner','FacaNaCaveira','786553'),
		 ('Amanda','Botelhão','Absurdo'),
		 ('Marina','Nina','SharkTank')

select * from Usuario 
delete from Usuario where idUsuario


INSERT INTO TopicoForum (titulo,descricao) 
    values ('BitCoins mudou minha vida!','Venha ser rico vc tbm!'),
        ('Nintendo Labo é uma bosta','Deixe sua opinião'),
        ('Paragon o melhor jogo!','Videos com melhores jogadas!')

select * from TopicoForum

INSERT INTO Postagem (idTopico,idUsuario,mensagem) 
    values (1,1,'VAI EXPLODIR!!!!!!'),
        (4,2,'250 dolares eh um roubo descarado'),
        (3,3,'Nerfem o Wukong pelo amor de Cristo!!!!!!!')

select * from Postagem
