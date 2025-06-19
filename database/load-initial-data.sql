USE TechRacingF1;
GO

-- 1. Pilotos (niveles de habilidad)
INSERT INTO DRIVERS(fullname,team, nationality, driver_level, truculence, experience) VALUES
('Lewis Hamilton', 'Mercedes','U.S.', 0.95, 0.85, 300),
('Max Verstappen','Ferrary','U.S.', 0.97, 0.92, 150),
('Charles Leclerc','Willians','Aleman', 0.90, 0.88, 100),
('Lando Norris','Red Bull','Ruso', 0.88, 0.80, 80);

-- 2. Neumáticos (tipos y rendimientos)
INSERT INTO TYRES(tyre_type, quality, base_degradation, speed_kmh) VALUES
('Blando', 0.95, 0.35, 340),
('Medio', 0.85, 0.25, 335),
('Duro', 0.75, 0.15, 330);

-- 3. Clima (condiciones variables)
INSERT INTO WEATHERS (condition, temperature, humidity, risk_factor) VALUES
('Seco', 28.5, 40, 1.0),
('Lluvia ligera', 22.0, 75, 1.15),
('Lluvia intensa', 19.5, 95, 1.30),
('Nublado', 25.0, 60, 1.05);

-- 4. Pistas (características únicas)
INSERT INTO TRACKS (track_name, country, track_length, curves, asphalt_type, tyre_wear) VALUES
('Monza', 'Italia', 5.79, 11, 'Liso', 1.15),
('Mónaco', 'Mónaco', 3.34, 19, 'Rugoso', 1.40),
('Silverstone', 'UK', 5.89, 18, 'Mixto', 1.25),
('Spa', 'Bélgica', 7.00, 20, 'Rugoso', 1.35);

-- 5. Autos (dificultad de manejo)
INSERT INTO CARS (model, difficulty, fuel_consumption, vel_max, engine_technology) VALUES
('Mercedes W15', 0.20, 2.8, 360, 'Híbrido V6'),
('Red Bull RB20', 0.18, 2.7, 362, 'Híbrido Turbo'),
('Ferrari SF-24', 0.22, 2.9, 358, 'Híbrido V6');