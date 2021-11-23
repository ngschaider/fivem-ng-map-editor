using CitizenFX.Core;

namespace EssentialsExtended {
    public class VehicleProperties {
        public dynamic Raw;

        public VehicleProperties() {
        }

        public VehicleProperties(dynamic data) => Raw = data;

        public uint Model {
            get => Raw.model;
            set => Raw.model = value;
        }

        public string Plate {
            get => Raw.plate;
            set => Raw.plate = value;
        }

        public int PlateIndex {
            get => Raw.plateIndex;
            set => Raw.plateIndex = value;
        }

        public float BodyHealth {
            get => Raw.bodyHealth;
            set => Raw.bodyHealth = value;
        }

        public float EngineHealth {
            get => Raw.engineHealth;
            set => Raw.engineHealth = value;
        }

        public float TankHealth {
            get => Raw.tankHealth;
            set => Raw.tankHealth = value;
        }

        public float FuelLevel {
            get => Raw.fuelLevel;
            set => Raw.fuelLevel = value;
        }

        public float DirtLevel {
            get => Raw.dirtLevel;
            set => Raw.dirtLevel = value;
        }

        public VehicleColor Color1 {
            get => (VehicleColor)Raw.color1;
            set => Raw.color1 = (int)value;
        }

        public VehicleColor Color2 {
            get => (VehicleColor)Raw.color2;
            set => Raw.color2 = (int)value;
        }

        public VehicleColor PearlescentColor {
            get => (VehicleColor)Raw.pearlescentColor;
            set => Raw.pearlescentColor = (int)value;
        }

        public VehicleColor WheelColor {
            get => (VehicleColor)Raw.wheelColor;
            set => Raw.wheelColor = (int)value;
        }

        public VehicleWheelType Wheels {
            get => (VehicleWheelType)Raw.wheels;
            set => Raw.wheels = (int)value;
        }

        public VehicleWindowTint WindowTint {
            get => (VehicleWindowTint)Raw.windowTint;
            set => Raw.windowTint = (int)value;
        }

        public bool[] NeonEnabled {
            get => Raw.neonEnabled;
            set => Raw.neonEnabled = value;
        }

        public dynamic NeonColor {
            get => Raw.neonColor;
            set => Raw.neonColor = value;
        }

        public dynamic Extras {
            get => Raw.extras;
            set => Raw.extras = value;
        }

        public dynamic TyreSmokeColor {
            get => Raw.tyreSmokeColor;
            set => Raw.tyreSmokeColor = value;
        }

        public int ModSpoilers {
            get => Raw.modSpoilers;
            set => Raw.modSpoilers = value;
        }

        public int ModFrontBumper {
            get => Raw.modFrontBumper;
            set => Raw.modFrontBumper = value;
        }

        public int ModRearBumper {
            get => Raw.modRearBumper;
            set => Raw.modRearBumper = value;
        }

        public int ModSideSkirt {
            get => Raw.modSideSkirt;
            set => Raw.modSideSkirt = value;
        }

        public int ModExhaust {
            get => Raw.modExhaust;
            set => Raw.modExhaust = value;
        }

        public int ModFrame {
            get => Raw.modFrame;
            set => Raw.modFrame = value;
        }

        public int ModGrille {
            get => Raw.modGrille;
            set => Raw.modGrille = value;
        }

        public int ModHood {
            get => Raw.modHood;
            set => Raw.modHood = value;
        }

        public int ModFender {
            get => Raw.modFender;
            set => Raw.modFender = value;
        }

        public int ModRightFender {
            get => Raw.modRightFender;
            set => Raw.modRightFender = value;
        }

        public int ModRoof {
            get => Raw.modRoof;
            set => Raw.modRoof = value;
        }

        public int ModEngine {
            get => Raw.modEngine;
            set => Raw.modEngine = value;
        }

        public int ModBrakes {
            get => Raw.modBrakes;
            set => Raw.modBrakes = value;
        }

        public int ModTransmission {
            get => Raw.modTransmission;
            set => Raw.modTransmission = value;
        }

        public int ModHorns {
            get => Raw.modHorns;
            set => Raw.modHorns = value;
        }

        public int ModSuspension {
            get => Raw.modSuspension;
            set => Raw.modSuspension = value;
        }

        public int ModArmor {
            get => Raw.modArmor;
            set => Raw.modArmor = value;
        }

        public int ModTurbo {
            get => Raw.modTurbo;
            set => Raw.modTurbo = value;
        }

        public int ModSmokeEnabled {
            get => Raw.modSmokeEnabled;
            set => Raw.modSmokeEnabled = value;
        }

        public int ModXenon {
            get => Raw.modXenon;
            set => Raw.modXenon = value;
        }

        public int ModFrontWheels {
            get => Raw.modFrontWheels;
            set => Raw.modFrontWheels = value;
        }

        public int ModBackWheels {
            get => Raw.modBackWheels;
            set => Raw.modBackWheels = value;
        }

        public int ModPlateHolder {
            get => Raw.modPlateHolder;
            set => Raw.modPlateHolder = value;
        }

        public int ModVanityPlate {
            get => Raw.modVanityPlate;
            set => Raw.modVanityPlate = value;
        }

        public int ModTrimA {
            get => Raw.modTrimA;
            set => Raw.modTrimA = value;
        }

        public int ModOrnaments {
            get => Raw.modOrnaments;
            set => Raw.modOrnaments = value;
        }

        public int ModDashboard {
            get => Raw.modDashboard;
            set => Raw.modDashboard = value;
        }
        public int ModDial {
            get => Raw.modDial;
            set => Raw.modDial = value;
        }

        public int ModDoorSpeaker {
            get => Raw.modDoorSpeaker;
            set => Raw.modDoorSpeaker = value;
        }

        public int ModSeats {
            get => Raw.modSeats;
            set => Raw.modSeats = value;
        }

        public int ModSteeringWheel {
            get => Raw.modSteeringWheel;
            set => Raw.modSteeringWheel = value;
        }

        public int ModShifterLeavers {
            get => Raw.modShifterLeavers;
            set => Raw.modShifterLeavers = value;
        }

        public int ModAPlate {
            get => Raw.modAPlate;
            set => Raw.modAPlate = value;
        }

        public int ModSpeakers {
            get => Raw.modSpeakers;
            set => Raw.modSpeakers = value;
        }

        public int ModTrunk {
            get => Raw.modTrunk;
            set => Raw.modTrunk = value;
        }

        public int ModHydrolic {
            get => Raw.modHydrolic;
            set => Raw.modHydrolic = value;
        }

        public int ModEngineBlock {
            get => Raw.modEngineBlock;
            set => Raw.modEngineBlock = value;
        }

        public int ModAirFilter {
            get => Raw.modAirFilter;
            set => Raw.modAirFilter = value;
        }

        public int ModStruts {
            get => Raw.modStruts;
            set => Raw.modStruts = value;
        }

        public int ModArchCover {
            get => Raw.modArchCover;
            set => Raw.modArchCover = value;
        }

        public int ModAerials {
            get => Raw.modAerials;
            set => Raw.modAerials = value;
        }

        public int ModTrimB {
            get => Raw.modTrimB;
            set => Raw.modTrimB = value;
        }

        public int ModTank {
            get => Raw.modTank;
            set => Raw.modTank = value;
        }

        public int ModWindows {
            get => Raw.modWindows;
            set => Raw.modWindows = value;
        }

        public int ModLivery {
            get => Raw.modLivery;
            set => Raw.modLivery = value;
        }
    }
}