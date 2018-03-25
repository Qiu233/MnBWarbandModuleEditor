using ModuleUnserializer.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ModuleUnserializer.Entities
{
	public class Particle_System
	{
		public ModuleInfo Module;
		public string Index;
		public BigInteger Flags;
		public string MeshName;
		public int ParticlesPerSecond;
		public float Life;
		public float Damping;
		public float GravityStrength;
		public float TurbulanceSize;
		public float TurbulanceStrength;

		public float Alpha11, Alpha12;
		public float Alpha21, Alpha22;
		public float Red11, Red12;
		public float Red21, Red22;
		public float Green11, Green12;
		public float Green21, Green22;
		public float Blue11, Blue12;
		public float Blue21, Blue22;
		public float Scale11, Scale12;
		public float Scale21, Scale22;
		public float EmitBoxSize1, EmitBoxSize2, EmitBoxSize3;
		public float EmitVelocity1, EmitVelocity2, EmitVelocity3;
		public float EmitDirectionRandomness;
		public float RotationSpeed;
		public float RotationDamping;



		private Particle_System()
		{

		}
		public static Particle_System FromString(ModuleInfo mInfo, string[] s, ref int j)
		{
			Particle_System ptc_sys = new Particle_System();
			ptc_sys.Module = mInfo;
			ptc_sys.Index = s[j++];
			ptc_sys.Index = ptc_sys.Index.Substring(ptc_sys.Index.IndexOf("_") + 1);
			ptc_sys.Flags = BigInteger.Parse(s[j++]);
			ptc_sys.MeshName = s[j++];
			ptc_sys.ParticlesPerSecond = Convert.ToInt32(s[j++]);
			ptc_sys.Life = Convert.ToSingle(s[j++]);
			ptc_sys.Damping = Convert.ToSingle(s[j++]);
			ptc_sys.GravityStrength = Convert.ToSingle(s[j++]);
			ptc_sys.TurbulanceSize = Convert.ToSingle(s[j++]);
			ptc_sys.TurbulanceStrength = Convert.ToSingle(s[j++]);
			ptc_sys.Alpha11 = Convert.ToSingle(s[j++]);
			ptc_sys.Alpha12 = Convert.ToSingle(s[j++]);
			ptc_sys.Alpha21 = Convert.ToSingle(s[j++]);
			ptc_sys.Alpha22 = Convert.ToSingle(s[j++]);
			ptc_sys.Red11 = Convert.ToSingle(s[j++]);
			ptc_sys.Red12 = Convert.ToSingle(s[j++]);
			ptc_sys.Red21 = Convert.ToSingle(s[j++]);
			ptc_sys.Red22 = Convert.ToSingle(s[j++]);
			ptc_sys.Green11 = Convert.ToSingle(s[j++]);
			ptc_sys.Green12 = Convert.ToSingle(s[j++]);
			ptc_sys.Green21 = Convert.ToSingle(s[j++]);
			ptc_sys.Green22 = Convert.ToSingle(s[j++]);
			ptc_sys.Blue11 = Convert.ToSingle(s[j++]);
			ptc_sys.Blue12 = Convert.ToSingle(s[j++]);
			ptc_sys.Blue21 = Convert.ToSingle(s[j++]);
			ptc_sys.Blue22 = Convert.ToSingle(s[j++]);
			ptc_sys.Scale11 = Convert.ToSingle(s[j++]);
			ptc_sys.Scale12 = Convert.ToSingle(s[j++]);
			ptc_sys.Scale21 = Convert.ToSingle(s[j++]);
			ptc_sys.Scale22 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitBoxSize1 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitBoxSize2 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitBoxSize3 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitVelocity1 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitVelocity1 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitVelocity1 = Convert.ToSingle(s[j++]);
			ptc_sys.EmitDirectionRandomness = Convert.ToSingle(s[j++]);
			ptc_sys.RotationSpeed = Convert.ToSingle(s[j++]);
			ptc_sys.RotationDamping = Convert.ToSingle(s[j++]);

			return ptc_sys;
		}
	}
}
