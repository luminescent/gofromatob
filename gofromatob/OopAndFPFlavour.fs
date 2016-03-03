module OopAndFPFlavour

open System

exception NotImplemented of string 

type Destination = { Id: string}
type Characteristics = { Id: string}
type RouteSegment = { Start: Destination; End: Destination; Characteristics: Characteristics}
type Route = { Id: string; Segments: RouteSegment list}

// Fuel? we assume perpetuum mobile for phase 1 
type Transporter = {Id: string; }
type Passenger = {Name: string; IsCertified: bool}

type DriverType =
    | Transporter 
    | Human 
type Driver = {Name: string; Type: DriverType}

// assumming here... 
type Cost = {Value: Decimal}

type Result =
    | Succeeded 
    | Failed // ?
    | YouAreAllTooFat
    | Malfunction  // ? 
type EmbarkingResult = Result
type EjectingResult = Result


type DrivingResult = 
    | InterruptedByUserOverride   
    | Succeeded
    | Accident
    | Malfunction 
    | Stopped // ?
     
type TransportProcuremnet =
    | Transporter of Transporter
    | NotFound
    | CostTooLow

type JourneyResult = 
    | Succeeded
    | Failed 


// driver does not count as passenger 
type TransportProcurer = Driver -> Passenger list -> Destination -> Destination -> Cost -> TransportProcuremnet
let procureTransport (driver: Driver) (passengers: Passenger list) (a: Destination) (b: Destination) (cost: Cost): TransportProcuremnet = 
     raise (NotImplemented("yet"))

type Embarker = Transporter -> Driver -> Passenger list -> EmbarkingResult
let embark (transporter: Transporter) (driver: Driver) (passengers: Passenger list) : EmbarkingResult = 
     raise (NotImplemented("yet"))
    
type BootOuter = Transporter -> Driver -> Passenger list -> EjectingResult
let eject (transporter: Transporter) (driver: Driver) (passengers: Passenger list) : EjectingResult = 
     raise (NotImplemented("yet"))

// we should fold on the Route 
type Drive = Driver -> Passenger list -> Transporter -> RouteSegment -> DrivingResult
let drive (transporter: Transporter) (driver: Driver) (passengers: Passenger list) (segment: RouteSegment) : DrivingResult = 
     raise (NotImplemented("yet"))


let journey (driver: Driver) (passengers: Passenger list) (a: Destination) (b: Destination) (cost: Cost) 
            (procureTransportFunc: TransportProcurer) (embarkFunc: Embarker) (ejectFunc: BootOuter)
            (driveFunc: Drive) : JourneyResult = 

    match procureTransport driver passengers a b cost with 
    | NotFound -> 
        JourneyResult.Failed
    | CostTooLow ->
        JourneyResult.Failed
    | Transporter transporter ->
        // now embark
        // drive 
        // we need a maybe (or either?) computational expression for segments 
        // to fold on it 
        // https://github.com/swlaschin/Railway-Oriented-Programming-Example
        // then get out 
        match embarkFunc transporter driver passengers with 
        | EmbarkingResult.Succeeded -> 
            
            // 

        | _ -> 
            JourneyResult.Failed
    


type IInvoker = 
    abstract ProcureTransport : Driver -> Passenger list -> Destination -> Destination -> Transporter 

type ITransporter = 
    abstract Embark : Embarker
    abstract Eject : BootOuter
    abstract Drive: Drive 






 
