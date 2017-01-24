using System;
using TheoryLib.LinearAlgebra;

namespace TheoryLib.Physics {

   internal enum Variable {
      Time, Velocity, Distance
   }

   public class Projectile3D {
      private Vector3D dis;
      private Velocity3D vel;
      private float t;
      public Velocity3D Velocity { get { return this.vel; } private set { this.vel = value; } }
      public Vector3D Distance { get { return this.dis; } private set { this.dis = value; } }
      public float Time { get { return this.t; } private set { this.t = value; } }
      public Vector3D UnitDistance { get { return this.dis.UnitVector; } }

      public Projectile3D( Vector3D Distance_o , float Time ) {
         this.dis = Distance_o;
         this.t = Time;
         this.Calculate( Variable.Velocity );
      }

      public Projectile3D( Vector3D Distance_o , Velocity3D Velocity_o ) {
         this.vel = Velocity_o;
         this.dis = Distance_o;
         this.Calculate( Variable.Time );
      }

      public Projectile3D( Velocity3D Velocity_o , float Time ) {
         this.vel = Velocity_o;
         this.t = Time;
         this.Calculate( Variable.Distance );
      }

      private void Calculate( Variable Var ) {
         switch( Var ) {
            case Variable.Velocity:
               this.Velocity = new Vector3D( this.Distance.X / this.Time , ( this.Distance.Y - ( 0.5f * Mathematics.Constants.Gravity * ( float )Math.Pow( this.Time , 2 ) ) ) / this.Time , this.Distance.Z / this.Time );
               break;

            case Variable.Distance:

            case Variable.Time:

            default:
               return;
         }
      }
   }
}