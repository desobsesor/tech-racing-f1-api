USE TechRacingF1;
GO

--Pilotos
CREATE TABLE DRIVERS(
	driver_id INT PRIMARY KEY IDENTITY(1,1),
	fullname VARCHAR(80) NOT NULL,
	team VARCHAR(80) NOT NULL,
	nationality VARCHAR(20) NOT NULL,
	driver_level DECIMAL(3,2), --0,9 EXPERTO
	truculence DECIMAL(3,2), -- agresividad
	experience INT NOT NULL--
);

--Autos
CREATE TABLE CARS(
	card_id INT PRIMARY KEY IDENTITY(1,1),
	model VARCHAR(50), 
	difficulty DECIMAL(3,2) , --0,9 dificil
	vel_max INT NOT NULL, --velocidad maxima en km/h
	fuel_consumption DECIMAL(3,2),
	engine_technology VARCHAR(MAX),
);

--Pistas
CREATE TABLE TRACKS(
	track_id INT PRIMARY KEY IDENTITY(1,1),
	track_name VARCHAR(50) NOT NULL,
	country VARCHAR(50) NOT NULL,
	track_length DECIMAL(3,2), --longitud en km
	curves INT NOT NULL,
	asphalt_type VARCHAR(20), --tipo de asfalto
	tyre_wear DECIMAL(3,2) --0,9 porcentaje de desgaste
);

--Clima
CREATE TABLE WEATHERS(
	weather_id INT PRIMARY KEY IDENTITY(1,1),
	condition VARCHAR(20) NOT NULL, 
	humidity INT NOT NULL,
	temperature INT NOT NULL,
	risk_factor DECIMAL(3,2) NOT NULL --0,9 factor de riesgo
);

--Neumaticos
CREATE TABLE TYRES(
	tyre_id INT PRIMARY KEY IDENTITY(1,1),
	tyre_type VARCHAR(20) NOT NULL,
	quality DECIMAL(3,2) NOT NULL,
	base_degradation DECIMAL(3,2) NOT NULL, --0,9 desgaste base
	speed_kmh INT NOT NULL --velocidad limite en km/h
);

--Estrategias
CREATE TABLE STRATEGIES(
	strategy_id INT PRIMARY KEY IDENTITY(1,1),
	strategy_name VARCHAR(50),
	total_laps INT NOT NULL, --numero de vueltas
	planned_stops INT NOT NULL, --numero de paradas planeadas
	estimated_time DECIMAL(6,2) NOT NULL, --tiempo estimado en minutos
	risk DECIMAL(3,2) NOT NULL, 
	weather_id INT FOREIGN KEY REFERENCES WEATHERS(weather_id),
	track_id INT FOREIGN KEY REFERENCES TRACKS(track_id),
);

--DetalleEstrategia
CREATE TABLE STRATEGY_DETAIL(
	strategy_detail_id INT PRIMARY KEY IDENTITY(1,1),
	strategy_id INT FOREIGN KEY REFERENCES STRATEGIES(strategy_id),
	tyre_id INT FOREIGN KEY REFERENCES TYRES(tyre_id),
	driver_id INT FOREIGN KEY REFERENCES DRIVERS(driver_id),
	curve_segment INT NOT NULL,
	order_segment INT NOT NULL
);

--Paradas a pits
CREATE TABLE PIT_STOPS(
	pit_stop_id INT PRIMARY KEY IDENTITY(1,1),
	strategy_id INT FOREIGN KEY REFERENCES STRATEGIES(strategy_id),
	lap INT NOT NULL, 
	time_seconds DECIMAL(4,2),
	previous_tyre_id INT FOREIGN KEY REFERENCES TYRES(tyre_id),
	new_tyre_id INT FOREIGN KEY REFERENCES TYRES(tyre_id),
);

--Simulacion
CREATE TABLE SIMULATIONS(
	simulation_id INT PRIMARY KEY IDENTITY(1,1),
	strategy_id INT FOREIGN KEY REFERENCES STRATEGIES(strategy_id),
	execution_date DATETIME2 NOT NULL,
	weather_id INT FOREIGN KEY REFERENCES WEATHERS(weather_id), 
	track_id INT FOREIGN KEY REFERENCES TRACKS(track_id),
	total_time DECIMAL(6,2) NOT NULL,
	royal_stops INT NOT NULL,
	average_wear DECIMAL(5,2) NOT NULL,
	final_state VARCHAR(20) NOT NULL,
);

--LogSimulacion
CREATE TABLE SIMULATION_LOGS(
	simulation_log_id INT PRIMARY KEY IDENTITY(1,1),
	simulation_id  INT FOREIGN KEY REFERENCES SIMULATIONS(simulation_id), 
	lap INT NOT NULL,
	time_lap DECIMAL(5,2) NOT NULL,
	tyre_id INT FOREIGN KEY REFERENCES TYRES(tyre_id), 
	current_wear DECIMAL(10,2),
	remaining_fuel DECIMAL(10,2),
	weather_id INT FOREIGN KEY REFERENCES WEATHERS(weather_id), 
	created_at DATETIME2 DEFAULT GETDATE()
);

--Consulta a simulaciones y las estrategias
--
CREATE VIEW VW_SIMULATIONS_STRATEGIES
AS
SELECT 
	ST.strategy_id, 
	ST.strategy_name,
	T.tyre_type,
	AVG(S.total_time) average_time,
	COUNT(S.simulation_id) as simulations,
	SUM(CASE WHEN S.final_state= 'Completado' then 1 else 0 end) as successful
FROM STRATEGIES ST
JOIN STRATEGY_DETAIL SD ON SD.strategy_id = ST.strategy_id
JOIN TYRES T ON SD.tyre_id = T.tyre_id
JOIN DRIVERS D ON SD.driver_id = D.driver_id
JOIN SIMULATIONS S ON ST.strategy_id = S.strategy_id
GROUP BY 
	ST.strategy_id, 
	ST.strategy_name,
	T.tyre_type;