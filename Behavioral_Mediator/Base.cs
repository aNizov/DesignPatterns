using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral_Mediator.Base
{
    public class Program
    {
        static void Main(string[] args)
        {
            var yytCenter = new YytCenter();

            var flight1 = new Airbus321("AC159", yytCenter);
            var flight2 = new Boeing737200("WS203", yytCenter);
            var flight3 = new Embraer190("AC602", yytCenter);

            flight1.Altitude += 1000;

        }
    }

    public interface IAirTrafficControl
    {
        void ReceiveAircraftLocation(Aircraft location);
        void RegisterAircraftUnderGuidance(Aircraft aircraft);
    }
    public abstract class Aircraft
    {
        private readonly IAirTrafficControl _atc;
        private int _currentAltitude;

        public Aircraft(string callSign, IAirTrafficControl atc)
        {
            _atc = atc;
            this.CallSign = callSign;
            _atc.RegisterAircraftUnderGuidance(this);
        }
        public abstract int Ceiling { get; }
        public string CallSign { get; }
        public int Altitude
        {
            get => _currentAltitude;
            set
            {
                _currentAltitude = value;
                _atc.ReceiveAircraftLocation(this);
            }
        }
        public void Climb(int heightToClimb)
        {
                Altitude += heightToClimb;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var incoming = (Aircraft)obj;
            return this.CallSign.Equals(incoming.CallSign);
        }
        public override int GetHashCode()
        {
            return CallSign.GetHashCode();
        }
        public void WarnOfAirspaceIntrusionBy(Aircraft reportingAircraft)
        {
            //do something in response to the warning
        }
    }
    public class Airbus321 : Aircraft
    {
        public Airbus321(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }
        public override int Ceiling => 41000;
    }
    public class Embraer190 : Aircraft
    {
        public Embraer190(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }
        public override int Ceiling => 41000;
    }
    public class Boeing737200 : Aircraft
    {
        public Boeing737200(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }
        public override int Ceiling => 35000;
    }

    public class YytCenter : IAirTrafficControl
    {
        private readonly IList<Aircraft> _aircraftUnderGuidance = new List<Aircraft>();

        public void ReceiveAircraftLocation(Aircraft reportingAircraft)
        {
            foreach (var currentAircraftUnderGuidance in _aircraftUnderGuidance.Where(x => x != reportingAircraft))
            {
                if (Math.Abs(currentAircraftUnderGuidance.Altitude - reportingAircraft.Altitude) < 1000)
                {
                    reportingAircraft.Climb(1000);
                    //communicate to the class
                    currentAircraftUnderGuidance.WarnOfAirspaceIntrusionBy(reportingAircraft);
                }
            }
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            if (!_aircraftUnderGuidance.Contains(aircraft))
            {
                _aircraftUnderGuidance.Add(aircraft);
            }
        }
    }

}
