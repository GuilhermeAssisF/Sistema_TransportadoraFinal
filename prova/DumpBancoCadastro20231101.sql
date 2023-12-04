DROP TABLE IF EXISTS `generos`;

CREATE TABLE `generos` (
  `idgenero` int NOT NULL AUTO_INCREMENT,
  `genero` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idgenero`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


LOCK TABLES `generos` WRITE;

INSERT INTO `generos` VALUES (1,'Rock'),(2,'Metal'),(3,'Pagode'),(4,'Gospel'),(5,'Funk');

UNLOCK TABLES;

DROP TABLE IF EXISTS `bandas`;

CREATE TABLE `bandas` (
  `idbandas` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  `integrantes` int DEFAULT NULL,
  `ranking` int DEFAULT NULL,
  `fk_genero` int DEFAULT NULL,
  PRIMARY KEY (`idbandas`),
  KEY `genero_idx` (`fk_genero`),
  CONSTRAINT `genero` FOREIGN KEY (`fk_genero`) REFERENCES `generos` (`idgenero`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;



LOCK TABLES `bandas` WRITE;

INSERT INTO `bandas` VALUES (1,'Skank',5,1,1),(2,'Metallica',4,1,1);

UNLOCK TABLES;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insereBanda`(nome varchar(45), 
                                   integrantes int, ranking int, genero int)
BEGIN
INSERT INTO `bandas`
(`nome`,
`integrantes`,
`ranking`,
`fk_genero`)
VALUES
(nome,
integrantes,
ranking,
genero);
END ;;
DELIMITER ;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listaBandas`()
BEGIN
     Select * from bandas;
END ;;
DELIMITER ;

DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_listaGeneros`()
BEGIN
   select * from generos;
END;;
DELIMITER ;
