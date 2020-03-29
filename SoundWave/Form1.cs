using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Windows.Input;
using NAudio.Wave;
using SoundWave.ConnectionStyle;

namespace SoundWave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private IWaveProvider GetProvider()
        {
            //TODO: double or decimal, what is best?
            SoundPitch playbackRate = new SoundPitch(48000);
            int playbackBits = 32;
            int playbackChannels = 2;
            SoundTime playbackDuration = new SoundTime(4.5); //seconds

            var sampleStream = new SampleStream(playbackDuration, playbackRate, playbackBits, playbackChannels);

            Track trackLeft = new Track(new SoundTime(0), new SampleValue(1));
            //Sound sound0Left = new Sound(new SoundTime(0), new SoundTime(4), new SampleValue(0.3), new SoundPitch((double)numFrequency.Value / 1000.0), new FilteredWhitenoiseWave(1, 40));
            Sound sound1Left = new Sound(new SoundTime(0), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 1000.0), SineWave.WaveSingleton);
            Sound sound1LeftS = new Sound(new SoundTime(0.5), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 500.0), SineWave.WaveSingleton);
            Sound sound2LeftS = new Sound(new SoundTime(1), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 1000.0), SineWave.WaveSingleton);
            Sound sound3LeftS = new Sound(new SoundTime(1.5), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 2000.0), SineWave.WaveSingleton);
            Sound sound4LeftS = new Sound(new SoundTime(2), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 800.0), SineWave.WaveSingleton);
            Sound sound5LeftS = new Sound(new SoundTime(2.5), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 3000.0), SineWave.WaveSingleton);
            Sound sound6LeftS = new Sound(new SoundTime(3), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 900.0), SineWave.WaveSingleton);
            Sound sound7LeftS = new Sound(new SoundTime(3.5), new SoundTime(0.1), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 4000.0), SineWave.WaveSingleton);

            Sound sound1FmLeft = new Sound(new SoundTime(0), new SoundTime(0.1), new SampleValue(1), new SoundPitch(10.0), SineWave.WaveSingleton);
            FrequencyMod fm1Left = new FrequencyMod(sound1FmLeft, SamplePhase.CreatePhaseChange(sampleStream.GetTimeForOneSample(), new SoundPitch(70)));
            sound1Left.ConnectFrequencyModulation(fm1Left);
            Sound sound1AmLeft = new Sound(new SoundTime(0), new SoundTime(0.1), new SampleValue(1), new SoundPitch(5), SineWave.WaveSingleton);
            AmplitudeMod am1Left = new AmplitudeMod(sound1AmLeft, new SampleValue(0));
            sound1Left.ConnectAmplitudeModulation(am1Left);
            sound1LeftS.ConnectFrequencyModulation(fm1Left);
            sound1LeftS.ConnectAmplitudeModulation(am1Left);
            sound2LeftS.ConnectFrequencyModulation(fm1Left);
            sound2LeftS.ConnectAmplitudeModulation(am1Left);
            sound3LeftS.ConnectFrequencyModulation(fm1Left);
            sound3LeftS.ConnectAmplitudeModulation(am1Left);
            sound4LeftS.ConnectFrequencyModulation(fm1Left);
            sound4LeftS.ConnectAmplitudeModulation(am1Left);
            sound5LeftS.ConnectFrequencyModulation(fm1Left);
            sound5LeftS.ConnectAmplitudeModulation(am1Left);
            sound6LeftS.ConnectFrequencyModulation(fm1Left);
            sound6LeftS.ConnectAmplitudeModulation(am1Left);
            sound7LeftS.ConnectFrequencyModulation(fm1Left);
            sound7LeftS.ConnectAmplitudeModulation(am1Left);
            trackLeft.AddSound(sound1Left);
            trackLeft.AddSound(sound1LeftS);
            trackLeft.AddSound(sound2LeftS);
            trackLeft.AddSound(sound3LeftS);
            trackLeft.AddSound(sound4LeftS);
            trackLeft.AddSound(sound5LeftS);
            trackLeft.AddSound(sound6LeftS);
            trackLeft.AddSound(sound7LeftS);
            IEffect effectLeft = new EchoEffect(0.53, 2500);
            trackLeft.ConnectSoundEffect(effectLeft);

            //Sound sound2Left = new Sound(new SoundTime(1), new SoundTime(3), new SampleValue(0.7), new SoundPitch((double)numFrequency.Value * 3 / 1000.0));
            //soundListLeft.AddSound(sound2Left);
            //Sound sound3Left = new Sound(new SoundTime(2), new SoundTime(2), new SampleValue(1), new SoundPitch((double)numFrequency.Value * 5 / 1000.0));
            //soundListLeft.AddSound(sound3Left);
            //Sound sound4Left = new Sound(new SoundTime(3), new SoundTime(1), new SampleValue(1), new SoundPitch((double)numFrequency.Value * 7 / 1000.0));
            //soundListLeft.AddSound(sound4Left);
            //Sound sound1AmLeft = new Sound(new SoundTime(0), new SoundTime(4), new SampleValue(1), new SoundPitch(3.5));
            //AmplitudeMod am1Left = new AmplitudeMod(sound1AmLeft, new SampleValue(0.5));
            //soundListLeft.ConnectAmplitudeModulation(am1Left);
            sampleStream.AddTrackForChannel(1, trackLeft, 1);

            //Track trackRight = new Track(new SoundTime(0), new SampleValue(1));
            //Sound sound1Right = new Sound(new SoundTime(0), new SoundTime(4), new SampleValue(0.1), new SoundPitch((double)numFrequency.Value / 1000.0), new FilteredWhitenoiseWave(1, 40));
            //Sound sound1RightS = new Sound(new SoundTime(0), new SoundTime(4), new SampleValue(1), new SoundPitch((double)numFrequency.Value / 1000.0), SineWave.WaveSingleton);
            //Sound sound1AmRight = new Sound(new SoundTime(0), new SoundTime(4), new SampleValue(1), new SoundPitch(3.5));
            //AmplitudeMod am1Right = new AmplitudeMod(sound1AmRight, new SampleValue(0.5));
            //sound1Right.ConnectAmplitudeModulation(am1Right);
            //trackRight.AddSound(sound1Right);
            //trackRight.AddSound(sound1RightS);
            //Sound sound1FmRight = new Sound(new SoundTime(0), new SoundTime(4), new SampleValue(1), new SoundPitch(10.0));
            //FrequencyMod fm1Right = new FrequencyMod(sound1FmRight, SamplePhase.CreatePhaseChange(sampleStream.GetTimeForOneSample(), new SoundPitch(70)));
            //soundListRight.ConnectFrequencyModulation(fm1Right);
            //sampleStream.AddTrackForChannel(2, trackRight, 1);
            sampleStream.AddTrackForChannel(2, trackLeft, 1);

            sampleStream.WriteAll();
            return new RawSourceWaveStream(sampleStream, new WaveFormat(playbackRate.PitchAsIntHz, playbackBits, playbackChannels));
        }

        private IWaveProvider GetProvider2()
        {
            int playbackRate = 48000;
            int playbackBits = 32;
            int playbackChannels = 2;
            decimal playbackDuration = 2; //seconds

            var soundStream = new SoundStream(playbackDuration, playbackRate, playbackBits, playbackChannels);

            //SoundBoxWave sound1 = new SoundBoxWave();
            //SoundBoxFrequency frequency = new SoundBoxFrequency(220.0);
            //SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0);
            //sound1.AddFrequencyOutputable(frequency.GetValueOutputable());
            //sound1.AddAmplitudeOutputable(amplitude.GetValueOutputable());

            //SoundBoxWave soundFM = new SoundBoxWave();
            //SoundBoxFrequency frequencyFM = new SoundBoxFrequency(5.0);
            //SoundBoxAmplitude amplitudeFM = new SoundBoxAmplitude(1.0);
            //sound1.AddFrequencyOutputable(soundFM.GetValueOutputable());

            //SoundBox sound2 = new SoundBox();
            //SoundBoxFrequency frequencyMod = new SoundBoxFrequency(5.0);
            //sound2.AddFrequencyOutputable(frequencyMod.GetValueOutputable());
            //sound2.AddValueOutputable(sound1.GetValueOutputable());

            //SoundBoxWave waveR = new SoundBoxWave();
            //SoundBoxFrequency frequencyR = new SoundBoxFrequency(220.0m);
            //SoundBoxAmplitude amplitudeR = new SoundBoxAmplitude(1.0m);
            //waveR.FrequencyInput(frequencyR.SignalOutput());
            //waveR.AmplitudeInput(amplitudeR.SignalOutput());

            //SoundBoxWave waveFmL = new SoundBoxWave();
            //SoundBoxFrequency frequencyFmL = new SoundBoxFrequency(10.0m);
            //SoundBoxAmplitude amplitudeFmL = new SoundBoxAmplitude(10.0m);
            //waveFmL.FrequencyInput(frequencyFmL.SignalOutput());
            //waveFmL.AmplitudeInput(amplitudeFmL.SignalOutput());

            //SoundBoxWave waveL = new SoundBoxWave();
            //SoundBoxFrequency frequencyL = new SoundBoxFrequency(220.0m);
            //SoundBoxAmplitude amplitudeL = new SoundBoxAmplitude(1.0m);
            //waveL.FrequencyInput(frequencyL.SignalOutput());
            //waveL.FrequencyInput(waveFmL.SignalOutput());
            //waveL.AmplitudeInput(amplitudeL.SignalOutput());

            //soundStream.SignalInput(1, waveL.SignalOutput());
            ////soundStream.SignalInput(2, waveR.SignalOutput());



            SoundBoxWave waveFM = new SoundBoxWave();
            SoundBoxFrequency frequencyFM = new SoundBoxFrequency(3.0m);
            SoundBoxAmplitude amplitudeFM = new SoundBoxAmplitude(1.0m);
            waveFM.FrequencyInput(frequencyFM.SignalOutput());
            waveFM.AmplitudeInput(amplitudeFM.SignalOutput());

            SoundBoxWave wave = new SoundBoxWave();
            SoundBoxFrequency frequency = new SoundBoxFrequency(220.0m, 10m);
            SoundBoxAmplitude amplitude = new SoundBoxAmplitude(1.0m);
            frequency.FrequencyFMInput(waveFM.SignalOutput());
            wave.FrequencyInput(frequency.SignalOutput());
            wave.AmplitudeInput(amplitude.SignalOutput());

            //SoundBoxWave wave2 = new SoundBoxWave();
            //wave2.FrequencyInput(frequency.SignalOutput());
            //wave2.AmplitudeInput(amplitude.SignalOutput());

            //SoundBox box = new SoundBox();
            //box.FrequencyInput(waveFM.SignalOutput());
            //box.FrequencyInput(frequency.SignalOutput());
            //box.AmplitudeInput(amplitude.SignalOutput());
            soundStream.SignalInput(1, wave.SignalOutput());
            //soundStream.SignalInput(2, wave2.SignalOutput());
            //soundStream.SignalInput(3, waveFM.SignalOutput());
            //soundStream.SignalInput(4, box.SignalOutput());
            soundStream.WriteAll();
            return new RawSourceWaveStream(soundStream, new WaveFormat(playbackRate, playbackBits, playbackChannels));
        }

        private void btnPlaySound_Click(object sender, EventArgs e)
        {
            WaveOut waveOut = new WaveOut(this.Handle);
            waveOut.Init(GetProvider2());
            waveOut.Play();
        }

        private void btnSaveWaveForm_Click(object sender, EventArgs e)
        {
            //WaveFileWriter waveFileWriter = new WaveFileWriter("file.wav", GetProvider().WaveFormat);
            //WaveStream sourceStream = new NullWaveStream(GetProvider().WaveFormat, 10000);
            WaveFileWriter.CreateWaveFile("file.wav", GetProvider2());
        }
    }
}


//The accepted answer assumes the byte stream is 44,1kHz, 16 bit, stereo.If you have something else you have to provide the coding in the WaveFormat
//byte[] bytes = new byte[1024];

//IWaveProvider provider = new RawSourceWaveStream(
//                         new MemoryStream(bytes), new WaveFormat(48000, 16, 1));

//_waveOut.Init(provider);
//_waveOut.Play();

//If your raw data is in fact a wav file you already have the encoding in the header and can use this method
//byte[] bytes = new byte[1024];

//WaveFileReader reader = new WaveFileReader(new MemoryStream(bytes));

//_waveOut.Init(reader);
//_waveOut.Play();
