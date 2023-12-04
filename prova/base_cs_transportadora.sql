CREATE TABLE `produtos` (
  `idproduto` int NOT NULL AUTO_INCREMENT,
  `produto` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idproduto`)
);

INSERT INTO `produtos` VALUES (1,'Areia'),(2,'Pedra'),(3,'Brita'),(4,'Calcario'),(5,'Composto');

CREATE TABLE `pedidos` (
  `idpedido` int NOT NULL AUTO_INCREMENT,
  `cliente` varchar(45) DEFAULT NULL,
  `valor` int DEFAULT NULL,
  `fk_produto` int DEFAULT NULL,
  PRIMARY KEY (`idpedido`),
  KEY `produto_idx` (`fk_produto`),
  CONSTRAINT `produtos` FOREIGN KEY (`fk_produto`) REFERENCES `produtos` (`idproduto`)
);