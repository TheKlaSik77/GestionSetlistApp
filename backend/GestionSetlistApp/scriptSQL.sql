-- Suppression de toutes les données

START TRANSACTION;

DELETE FROM `MembreEvenement`;
DELETE FROM `MembreJoueDe`;
DELETE FROM `MorceauSetlist`;
DELETE FROM `MembreSetlist`;

DELETE FROM `Evenements`;
DELETE FROM `Morceaux`;
DELETE FROM `Membres`;
DELETE FROM `Instruments`;
DELETE FROM `Setlists`;

COMMIT;

-- Id Réinitialisés
ALTER TABLE `Evenements`  AUTO_INCREMENT = 1;
ALTER TABLE `Membres`     AUTO_INCREMENT = 1;
ALTER TABLE `Morceaux`    AUTO_INCREMENT = 1;
ALTER TABLE `Instruments` AUTO_INCREMENT = 1;
ALTER TABLE `Setlists`    AUTO_INCREMENT = 1;
