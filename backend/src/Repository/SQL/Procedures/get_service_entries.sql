CREATE PROCEDURE GetServiceEntries
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CASE 
            WHEN LicensePlate IS NULL THEN '-'
            ELSE
                -- Plaka formatını belirle ve biçimlendir
                CASE
                    -- Plaka son 4 karakter rakam, öncekiler harfler
                    WHEN ISNUMERIC(RIGHT(LicensePlate, 4)) = 1 THEN 
                        -- İl kodu + harfler + rakamlar
                        SUBSTRING(LicensePlate, 1, 2) + ' ' +
                        SUBSTRING(LicensePlate, 3, LEN(LicensePlate) - 6) + ' ' +
                        RIGHT(LicensePlate, 4)
                    -- Plaka son 3 karakter rakam, öncekiler harfler
                    ELSE 
                        -- İl kodu + harfler + rakamlar
                        SUBSTRING(LicensePlate, 1, 2) + ' ' +
                        SUBSTRING(LicensePlate, 3, LEN(LicensePlate) - 5) + ' ' +
                        RIGHT(LicensePlate, 3)
                END
        END AS LicensePlate,
        
        ISNULL(BrandName, '-') AS BrandName,
        ISNULL(ModelName, '-') AS ModelName,
        CAST(Kilometers AS VARCHAR(10)) AS Kilometers,
        COALESCE(CAST(ModelYear AS VARCHAR(10)), '-') AS ModelYear,
        
        -- Türkiye formatında tarih: DD.MM.YYYY
        FORMAT(ServiceDate, 'dd.MM.yyyy') AS ServiceDate,
        
        CASE 
            WHEN HasWarranty IS NULL THEN '-'
            WHEN HasWarranty = 1 THEN 'Var'
            WHEN HasWarranty = 0 THEN 'Yok'
        END AS HasWarranty,
        
        ISNULL(ServiceCity, '-') AS ServiceCity,
        ISNULL(ServiceNotes, '-') AS ServiceNotes
    FROM
        ServiceEntries;
END
