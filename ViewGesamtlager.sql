USE Lagerverwaltung
go

CREATE VIEW v_Gesamtwert 
AS
SELECT TOP 3 LagerartikelId, L_Bezeichnung, Lagerstand, L_MengenEinheit, L_Preis, L_Preis * Lagerstand AS Gesamtlagermengenwert
FROM Lagerartikels
ORDER BY Gesamtlagermengenwert
go


SELECT *
FROM v_Gesamtwert