using Jint.Native.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jint.Benchmark
{
	class JsonParserBenchmark
	{
		BaselineJsonParser baselineParser;
		JsonParser newParser;
		Engine engine;
		string jsonData;

		public JsonParserBenchmark()
		{
			engine = new Engine();
			baselineParser = new BaselineJsonParser(engine);
			newParser = new JsonParser(engine);
			jsonData = File.ReadAllText("sample.json");
		}

		private const int SampleCount = 100,
			IterationsPerSample = 10;

		public void Run()
		{
			Stopwatch s = new Stopwatch();
			long[] baselineSamples = new long[SampleCount],
				newSamples = new long[SampleCount];

			GC.Collect();
			for(var i = 0; i < baselineSamples.Length; i++)
			{
				s.Restart();
				for(var j = 0; j < IterationsPerSample; j++) baselineParser.Parse(jsonData);
				baselineSamples[i] = s.ElapsedMilliseconds;
			}

			GC.Collect();
			for (var i = 0; i < newSamples.Length; i++)
			{
				s.Restart();
				for (var j = 0; j < IterationsPerSample; j++) newParser.Parse(jsonData);
				newSamples[i] = s.ElapsedMilliseconds;
			}

			Console.WriteLine($"Average baseline: {baselineSamples.Average():0000.00}ms");
			Console.WriteLine($"Average new     : {newSamples.Average():0000.00}ms");

			Console.ReadLine();
		}
	}
}
