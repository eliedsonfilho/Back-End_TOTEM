using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using BoletoNet;
using Dados;
using Microsoft.VisualBasic;
using Servicos;
using Util;
using Excel = Microsoft.Office.Interop.Excel;

namespace TestesWinForms
{
    public partial class NBoleto : Form
    {
        private Progresso _progresso;
        string _arquivo = string.Empty;
        private ImpressaoBoleto _impressaoBoleto;

        private ServicoDadosBoletoCobranca _servicoDadosBoletoCobranca;
        private DadosBoletoCobranca _dadosBoletoCobranca;
        private ServicoVSF_ConfiguracaoFinanceira _servicoVsfConfiguracaoFinanceira;
        private VSF_ConfiguracaoFinanceira _vsfConfiguracaoFinanceira;
        private ServicoBoletoCobranca _servicoBoletoCobranca;
        
        public NBoleto()
        {
            InitializeComponent();
        }

        void _impressaoBoleto_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
            Dispose();
        }
        
        private void GeraBoleto()
        {
            _servicoDadosBoletoCobranca = new ServicoDadosBoletoCobranca();
            _servicoVsfConfiguracaoFinanceira = new ServicoVSF_ConfiguracaoFinanceira();
            _servicoBoletoCobranca = new ServicoBoletoCobranca();

            ServicoCartaoIdentificacao servicoCartaoIdentificacao = new ServicoCartaoIdentificacao();
            CartaoIdentificacao cartaoIdentificacao;
            List<BoletoBancario> listaBoletos = new List<BoletoBancario>();
            BoletoCobranca boletoCobranca;
            List<int> listaIdDocFinanceiro = new List<int>();
            List<DateTime> listaDataVencimento = new List<DateTime>();

            if(radioButton1.Checked)//Busca aleatória
            {
                listaIdDocFinanceiro = new List<int>() { 2057970, 2047897, 2068007, 2055233, 2055234, 2070755, 
                                            2066412, 2067192, 2068163, 
                                            2051422, 2052291, 2056114, 2056739, 2058017, 2065023, 2065820, 2066302, 2066811, 
                                            2067487, 2067653, 2069188, 2070373, 2099077, 2047017, 2047052, 2047053, 2048060, 2049802,
                                            2052163, 2052455, 2055318, 2055548, 2056794, 2057851, 2070597, 2070819, 2070959, 2092412,
                                            2092470, 2099078, 2044583, 2044584, 2044833, 2045055, 2045599, 2046819, 2046852, 2047347,
                                            2047574, 2048405, 2049426, 2050269, 2050435, 2051524, 2052904, 2052995, 2053697, 2057096,
                                            2057323, 2057798, 2068001, 2069315, 2071003, 2071158, 2071268, 2071387, 2071550, 2072002,
                                            2072091, 2072108, 2072139, 2076234, 2076265, 2077082, 2092502, 2092512, 2092513, 2092514,
                                            2092550, 2098197, 2043787, 2044879, 2045024, 2045103, 2045494, 2045929, 2046184, 2046359,
                                            2047492, 2047565, 2048344, 2048870, 2049520, 2050503, 2050750, 2051222, 2051814, 2051837,
                                            2052364, 2052485, 2053451, 2053589, 2054201, 2054308, 2054393, 2055163, 2056561, 2056720,
                                            2064749, 2064961, 2064973, 2064976, 2065451, 2065566, 2066193, 2066594, 2066704, 2066787,
                                            2067296, 2067358, 2067599, 2067920, 2067921, 2068200, 2069750, 2070084, 2070089, 2070123,
                                            2070362, 2070656, 2070911, 2072015, 2072049, 2072054, 2072110, 2072218, 2072226,
                                            2072235, 2072240, 2072247, 2072260, 2072285, 2072311, 2072324, 2072345, 2072353, 2072356,
                                            2072398, 2072446, 2072506, 2072517, 2072853, 2072961, 2072983, 2073113, 2073182, 2073185,
                                            2073187, 2073190, 2073207, 2073219, 2073249, 2073254, 2073294, 2073295, 2073486, 2073505,
                                            2073517, 2073518, 2073550, 2073600, 2073626, 2073655, 2073679, 2073688, 2073689, 2073702,
                                            2073708, 2073710, 2073712, 2073724, 2073733, 2073734, 2073755, 2073758, 2073763, 2073767,
                                            2073783, 2073788, 2073795, 2073804, 2073807, 2073810, 2073829, 2073857, 2073863, 2073866,
                                            2073880, 2073889, 2073896, 2073908, 2073912, 2073916, 2073917, 2073920, 2073923, 2073949,
                                            2073961, 2073962, 2073964, 2073969, 2073983, 2073985, 2073991, 2074029, 2074032, 2074044,
                                            2074052, 2074058, 2074063, 2074064, 2074065, 2074085, 2074093, 2074099, 2074102, 2074109,
                                            2074112, 2074113, 2074126, 2074128, 2074143, 2074149, 2074150, 2074152, 2074166, 2074167,
                                            2074168, 2074175, 2074188, 2074204, 2074206, 2074216, 2074220, 2074229, 2074238, 2074244,
                                            2074248, 2074251, 2074273, 2074283, 2074291, 2074293, 2074295, 2074296, 2074318, 2074320,
                                            2074330, 2074334, 2074343, 2074350, 2074393, 2074422, 2074423, 2074426, 2074432, 2074468,
                                            2074531, 2074532, 2074544, 2074551, 2074618, 2074635, 2074656, 2074658, 2074659, 2074667,
                                            2074704, 2074759, 2074773, 2074800, 2074819, 2074851, 2074853, 2074910, 2074911, 2074915,
                                            2074921, 2074945, 2074961, 2074986, 2075010, 2075011, 2075030, 2075033, 2075055, 2075058,
                                            2075059, 2075066, 2075079, 2075080, 2075094, 2075126, 2075147, 2075155, 2075156, 2075168,
                                            2075203, 2075205, 2075221, 2077315, 2077469, 2099110, 2099111, 
                                            2099113, 2099115, 2099116, 2099117, 2072230, 2072232, 2072272, 2072552, 2072724,
                                            2073158, 2073681, 2073870, 2073947, 2073951, 2073958, 2074006, 2074026, 2074033, 2074054,
                                            2074069, 2074094, 2074096, 2074189, 2074214, 2074249, 2074326, 2074328, 2074333, 2074341, 
                                            2074354, 2074357, 2074360, 2074387, 2074398, 2074401, 2074405, 2074406, 2074419, 2074424,
                                            2074429, 2074435, 2074488, 2074489, 2074490, 2074509, 2074510, 2074511, 2074515, 2074521,
                                            2074522, 2074536, 2074549, 2074585, 2074586, 2074592, 2074627, 2074634, 2074665, 2074675,
                                            2074686, 2074699, 2074727, 2074735, 2074750, 2074775, 2074781, 2074790, 2074791, 2074811,
                                            2074816, 2074822, 2074825, 2074826, 2074832, 2074869, 2074879, 2074884, 2074888, 2074924,
                                            2074938, 2074940, 2074941, 2074942, 2074943, 2074944, 2074948, 2074957, 2074963, 2074974,
                                            2074976, 2074977, 2075017, 2075018, 2075021, 2075026, 2075063, 2075073, 2075076, 2075099,
                                            2075116, 2075134, 2075141, 2075158, 2075160, 2075177, 2075190, 2075218, 2075266, 2075282,
                                            2075289, 2075293, 2075294, 2075320, 2075339, 2075350, 2075355, 2075366, 2075367, 2075369,
                                            2075373, 2075378, 2075379, 2075381, 2075384, 2075408, 2075410, 2075416, 2075433, 2075438,
                                            2075439, 2075448, 2075458, 2075459, 2075472, 2075473, 2075491, 2075493, 2075494, 2075501,
                                            2075502, 2075506, 2075508, 2075509, 2075514, 2075517, 2075525, 2075526, 2075527, 2075532,
                                            2075538, 2075539, 2075554, 2075574, 2075576, 2075578, 2075580, 2075582, 2075585, 2075587,
                                            2075589, 2075591, 2075598, 2075601, 2075606, 2075609, 2075641, 2075647, 2075651, 2075657,
                                            2075662, 2075663, 2075680, 2075683, 2075685, 2075691, 2075693, 2075700, 2075706, 2075707,
                                            2075710, 2075713, 2075743, 2075746, 2075753, 2075757, 2075768, 2075772, 2075780, 2075781,
                                            2075782, 2075789, 2075799, 2075821, 2075824, 2075831, 2075832, 2075835, 2075837, 2075841,
                                            2075842, 2075843, 2075845, 2075872, 2075873, 2075877, 2075881, 2075891, 2075936, 2075941,
                                            2075943, 2075963, 2075988, 2075993, 2075996, 2076002, 2076004, 2076005, 2076013, 2076028,
                                            2076031, 2076034, 2076036, 2076039, 2076040, 2076067, 2076069, 2076072, 2076075, 2076076
                                            };

                listaDataVencimento = new List<DateTime>() { Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("20/06/2013"), 
Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("15/06/2013"), 
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), 
Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("20/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("14/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("01/06/2013"),
Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"),
Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"),
Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("05/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("20/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("12/06/2013"), Convert.ToDateTime("12/06/2013"), Convert.ToDateTime("12/06/2013"), Convert.ToDateTime("12/06/2013"),
Convert.ToDateTime("12/06/2013"), Convert.ToDateTime("13/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("01/06/2013"),
Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("01/06/2013"), Convert.ToDateTime("10/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("20/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"),
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("25/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), 
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("25/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), 
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("13/06/2013"), Convert.ToDateTime("13/06/2013"), 
Convert.ToDateTime("15/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("05/06/2013"), Convert.ToDateTime("10/06/2013"), 
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"),
Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013"), Convert.ToDateTime("30/06/2013")
                };

                int j = 0;
                foreach (int i in listaIdDocFinanceiro)
                {
                    try
                    {

                        boletoCobranca = _servicoBoletoCobranca.ObterBoletoCobrancaPorId(i, false, "TOTEM", null);
                        boletoCobranca.DataVencimento = listaDataVencimento[j];
                        listaBoletos.Add(GeraBoleto(boletoCobranca));
                        j++;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            else//Busca específica
            {
                cartaoIdentificacao = servicoCartaoIdentificacao.ObterCartaoIdentificacaoPorCodigo(textBox1.Text, false);

                boletoCobranca = _servicoBoletoCobranca.ObterTodosBoletosPorBeneficiario(cartaoIdentificacao.Beneficiario, "TOTEM", null).LastOrDefault();
                listaBoletos.Add(GeraBoleto(boletoCobranca));
                listaIdDocFinanceiro.Add(boletoCobranca.AutoIdDocFinan);
            }

            if (checkBox1.Checked)
            {
                GeraArquivo(listaBoletos, listaIdDocFinanceiro);
            }

            GeraLayout(listaBoletos);
        }

        private BoletoBancario GeraBoleto(BoletoCobranca boletoCobranca)
        {
            _dadosBoletoCobranca = _servicoDadosBoletoCobranca.ObterPorDocFinanceiro(boletoCobranca, "TOTEM", null);
            _vsfConfiguracaoFinanceira = _servicoVsfConfiguracaoFinanceira.ObterVSF_ConfiguracaoFinanceira(true, "TOTEM", null);

            Banco nomebanco = new Banco(Convert.ToInt32(_dadosBoletoCobranca.Banco));
            _dadosBoletoCobranca.Observacoes = ObterObservacaoBoleto(_servicoBoletoCobranca.VerificaBoletoVencido(boletoCobranca), nomebanco.Nome.ToUpper());

            //DADOS DO BANCO
            string vencimento = boletoCobranca.DataVencimento.ToString(@"dd/MM/yyyy");
            string moramulta = _servicoBoletoCobranca.CalculaJurosBoleto(boletoCobranca.DataVencimento, DateTime.Now.Date, _dadosBoletoCobranca.ValorLiquido, 
                                _vsfConfiguracaoFinanceira.PercentualJuros, _vsfConfiguracaoFinanceira.PercentualMulta).ToString("N2");
            string valorcobrado = (_dadosBoletoCobranca.ValorLiquido + Convert.ToDecimal(moramulta)).ToString("N2") ;
            string banco = _dadosBoletoCobranca.Banco;
            string valor = _dadosBoletoCobranca.ValorLiquido.ToString("N2");
            string nossonumero = _dadosBoletoCobranca.NossoNumero;
            string numerodocumento = _dadosBoletoCobranca.NumeroDocumento;
            string carteira = _dadosBoletoCobranca.Carteira;
            //DADOS DO CEDENTE
            string cnpcedente = _dadosBoletoCobranca.CnpCedente;
            string codigocedente = _dadosBoletoCobranca.CodigoCedente;
            string nomecedente = _dadosBoletoCobranca.NomeCedente;
            string agenciacedente = _dadosBoletoCobranca.Agencia;
            string contacedente = _dadosBoletoCobranca.NumeroConta;
            IList<string> instrucoes = new List<string>();
            instrucoes.Add(_dadosBoletoCobranca.Observacoes);
            instrucoes.Add("");//Quebra de Linha entre a Obersavaçoes do Boleto e a Instrução 
            instrucoes.Add(_vsfConfiguracaoFinanceira.InstrucoesBoleto);
            //DADOS DO SACADO
            string cnpsacado = _dadosBoletoCobranca.CnpSacado ?? "00000000000";
            string nomesacado = _dadosBoletoCobranca.NomeSacado;
            string enderecosacado = _dadosBoletoCobranca.EnderecoSacado ?? "";
            string bairrosacado = _dadosBoletoCobranca.BairroSacado ?? "";
            string cidadesacado = _dadosBoletoCobranca.CidadeSacado ?? "";
            string cepsacado = _dadosBoletoCobranca.CepSacado ?? "";
            string ufsacado = _dadosBoletoCobranca.UfSacado ?? "";

            //Remove dígito da Agência.
            int digAgencia = 0;
            int agencia = 0;
            if (agenciacedente.IndexOf("-") > -1)
            {
                int s = agenciacedente.IndexOf("-") + 1;
                int tam = Strings.Len(agenciacedente);
                digAgencia = Convert.ToInt32(Strings.Right(agenciacedente, tam - s));
                int dif = tam - (s - 1);
                //incluindo o traço.
                agencia = Convert.ToInt32(Strings.Left(agenciacedente, tam - dif));
            }
            else
            {
                int tam = Strings.Len(agenciacedente);
                digAgencia = Convert.ToInt32(Strings.Right(agenciacedente, 1));
                agencia = Convert.ToInt32(Strings.Left(agenciacedente, tam - 1));
            }

            //Remove dígito da Conta.
            int digConta = 0;
            int conta = 0;
            if (contacedente.IndexOf("-") > -1)
            {
                int s2 = contacedente.IndexOf("-") + 1;
                int tam2 = Strings.Len(contacedente);
                digConta = Convert.ToInt32(Strings.Right(contacedente, tam2 - s2));
                int dif2 = tam2 - (s2 - 1);
                //incluindo o traço.
                conta = Convert.ToInt32(Strings.Left(contacedente, tam2 - dif2));
            }
            else
            {
                int tam2 = Strings.Len(contacedente);
                digConta = Convert.ToInt32(Strings.Right(contacedente, 1));
                conta = Convert.ToInt32(Strings.Left(contacedente, tam2 - 1));
            }

            //Remove dígito do Cedente.
            int digCedente = 0;
            if (codigocedente.IndexOf("-") > -1)
            {
                int s3 = codigocedente.IndexOf("-") + 1;
                int tam3 = Strings.Len(codigocedente);
                digCedente = Convert.ToInt32(Strings.Right(codigocedente, tam3 - s3));
                int dif3 = tam3 - (s3 - 1);
                //incluindo o traço.
                codigocedente = Strings.Left(codigocedente, tam3 - dif3);
            }
            else
            {
                int tam3 = Strings.Len(codigocedente);
                digCedente = Convert.ToInt32(Strings.Right(codigocedente, 1));
                codigocedente = Strings.Left(codigocedente, tam3 - 1);
            }

            //Validação.
            switch (banco)
            {
                case "001"://Banco do Brasil.
                    //Agência com 4 caracteres.
                    if (Strings.Len(agencia) > 4)
                    {
                        MessageBox.Show("A Agência deve conter até 4 dígitos.");
                        return null;
                    }

                    //Conta com 8 caracteres.
                    if (Strings.Len(conta) > 8)
                    {
                        MessageBox.Show("A Conta deve conter até 8 dígitos.");
                        return null;
                    }

                    //Cedente com 8 caracteres.
                    if (Strings.Len(codigocedente) > 8)
                    {
                        MessageBox.Show("O Código do Cedente deve conter até 8 dígitos.");
                        return null;
                    }

                    //Nosso Número deve ser 11 ou 17 dígitos.
                    if (Strings.Len(nossonumero) != 11 & Strings.Len(nossonumero) != 17)
                    {
                        MessageBox.Show("O Nosso Número deve ter 11 ou 17 dígitos dependendo da Carteira.");
                        return null;
                    }

                    break;
                case "033"://Santander.
                case "070"://Banco BRB.
                case "104"://Caixa Econômica Federal.
                case "237"://Banco Bradesco.
                    break;
                case "275"://Banco Real.
                    //Cobrança registrada 7 dígitos.
                    //Cobrança sem registro até 13 dígitos.
                    if (Strings.Len(nossonumero) < 7 & Strings.Len(nossonumero) < 13)
                    {
                        MessageBox.Show("O Nosso Número deve ser entre 7 e 13 caracteres.");
                        return null;
                    }

                    //Carteira
                    if (carteira != "00" & carteira != "20" & carteira != "31" & carteira != "42" & carteira != "47" & carteira != "85" & carteira != "57")
                    {
                        MessageBox.Show("A Carteira deve ser 00,20,31,42,47,57 ou 85.");
                        return null;
                    }

                    //Agência 4 dígitos.
                    if (Strings.Len(agencia) > 4)
                    {
                        MessageBox.Show("A Agência deve conter até 4 dígitos.");
                        return null;
                    }

                    //Número da conta 6 dígitos.
                    if (Strings.Len(conta) > 6)
                    {
                        MessageBox.Show("A Conta Corrente deve conter até 6 dígitos.");
                        return null;
                    }

                    break;
                case "291"://Banco BCN.
                case "341"://Banco Itaú.
                case "347"://Banco Sudameris.
                    break;
                case "356"://Banco Real.
                    //Cobrança registrada 7 dígitos.
                    //Cobrança sem registro até 13 dígitos.
                    if (Strings.Len(nossonumero) < 7 & Strings.Len(nossonumero) < 13)
                    {
                        MessageBox.Show("O Nosso Número deve ser entre 7 e 13 caracteres.");
                        return null;
                    }

                    //Carteira
                    if (carteira != "00" & carteira != "20" & carteira != "31" & carteira != "42" & carteira != "47" & carteira != "85" & carteira != "57")
                    {
                        MessageBox.Show("A Carteira deve ser 00,20,31,42,47,57 ou 85.");
                        return null;
                    }
                    
                    //Agência 4 dígitos.
                    if (Strings.Len(agencia) > 4)
                    {
                        MessageBox.Show("A Agência deve conter até 4 dígitos.");
                        return null;
                    }

                    //Número da conta 6 dígitos.
                    if (Strings.Len(conta) > 6)
                    {
                        MessageBox.Show("A Conta Corrente deve conter até 6 dígitos.");
                        return null;
                    }

                    break;
                case "409"://Banco Unibanco.
                case "422"://Banco Safra.
                case "748"://Banco Sicredi.
                    break;
            }

            //Informa os dados do cedente
            Cedente cedente = new Cedente(cnpcedente, nomecedente, agencia.ToString(), digAgencia.ToString(), conta.ToString(), digConta.ToString());
            //Dependendo da carteira, é necessário informar o código do cedente (o banco que fornece)
            cedente.Codigo = Convert.ToInt32(codigocedente);
            cedente.DigitoCedente = Convert.ToInt32(digCedente);

            //Dados para preenchimento do boleto (data de vencimento, valor, carteira e nosso número)
            Boleto boleto = new Boleto(Convert.ToDateTime(vencimento), Convert.ToDecimal(valor), carteira, nossonumero, cedente);
            //Dependendo da carteira, é necessário o número do documento
            boleto.NumeroDocumento = numerodocumento;
            boleto.ValorCobrado = Convert.ToDecimal(valorcobrado);
            boleto.ValorMulta = Convert.ToDecimal(moramulta);
            //Informa os dados do sacado
            boleto.Sacado = new Sacado(cnpsacado, nomesacado);
            boleto.Sacado.Endereco.End = enderecosacado;
            boleto.Sacado.Endereco.Bairro = bairrosacado;
            boleto.Sacado.Endereco.Cidade = cidadesacado;
            boleto.Sacado.Endereco.CEP = cepsacado;
            boleto.Sacado.Endereco.UF = ufsacado;

            //Implementa Descrição do Boleto
            switch (banco)
            {
                case "001"://Banco do Brasil.
                case "033"://Santander.
                case "070"://Banco BRB.
                case "104"://Caixa Econômica Federal.
                case "237"://Banco Bradesco.
                case "275"://Banco Real.
                case "291"://Banco BCN.
                case "341"://Banco Itaú.
                case "347"://Banco Sudameris.
                case "356"://Banco Real.
                case "409"://Banco Unibanco.
                case "422"://Banco Safra.
                    {
                        IInstrucao i1;
                        foreach (string instru in instrucoes)
                        {
                            i1 = new Instrucao(Convert.ToInt32(banco));
                            i1.Descricao = instru;
                            boleto.Instrucoes.Add(i1);
                        }
                        break;
                    }
                default:
                    {
                        Instrucao_Santander i2;
                        foreach (string instrucao in instrucoes)
                        {
                            i2 = new Instrucao_Santander();
                            i2.Descricao = instrucao;
                            boleto.Instrucoes.Add(i2);
                        }
                        break;
                    }
            }

            //Espécie do Documento - [R] Recibo
            switch (banco)
            {
                case "001"://Banco do Brasil.
                    boleto.EspecieDocumento = new EspecieDocumento_BancoBrasil(2);
                    break;
                case "033"://Santander.
                    boleto.EspecieDocumento = new EspecieDocumento_Santander(17);
                    break;
                case "070"://Banco BRB.
                    boleto.EspecieDocumento = new EspecieDocumento(17);
                    break;
                case "104"://Caixa Econômica Federal.
                    boleto.EspecieDocumento = new EspecieDocumento_Caixa(17);
                    break;
                case "237"://Banco Bradesco.
                    boleto.EspecieDocumento = new EspecieDocumento(17);
                    break;
                case "275"://Banco Real.
                    boleto.EspecieDocumento = new EspecieDocumento(17);
                    break;
                case "291"://Banco BCN.
                    boleto.EspecieDocumento = new EspecieDocumento(17);
                    break;
                case "341"://Banco Itaú.
                    boleto.EspecieDocumento = new EspecieDocumento_Itau(99);
                    break;
                case "347"://Banco Sudameris.
                    boleto.EspecieDocumento = new EspecieDocumento_Sudameris(17);
                    break;
                case "356"://Banco Real.
                    break;
                case "409"://Banco Unibanco.
                    boleto.EspecieDocumento = new EspecieDocumento(17);
                    break;
                case "422"://Banco Safra.
                    boleto.EspecieDocumento = new EspecieDocumento(17);
                    break;
                default://Banco de teste Santander.
                    boleto.EspecieDocumento = new EspecieDocumento_Santander(17);
                    break;
            }

            BoletoBancario boletoBancario = new BoletoBancario();
            boletoBancario.CodigoBanco = Convert.ToInt16(banco);
            boletoBancario.Boleto = boleto;
            //boletoBancario.MostrarCodigoCarteira = True
            boletoBancario.Boleto.Valida();
            boletoBancario.MostrarComprovanteEntrega = false;

            return boletoBancario;
        }

        private string ObterObservacaoBoleto(bool boletoVencido, string nomeBanco)
        {
            string mensagem;
            string multa = Math.Round((_vsfConfiguracaoFinanceira.PercentualMulta * 100), 0).ToString() + "%";
            string juros = Math.Round((_vsfConfiguracaoFinanceira.PercentualJuros * 100) * 30, 0).ToString() + "%";
            string limiteDias = _vsfConfiguracaoFinanceira.LimiteDiasVencido.ToString();

            if (boletoVencido)
            {
                mensagem = "PAG. QUALQUER AGENCIA BANCARIA. SR. CAIXA, NÃO RECEBER ESSE DOCUMENTO APÓS O VENCIMENTO";
            }
            else
            {
                mensagem = string.Format(@"PAG. QUALQUER AGENCIA BANCARIA ATE O SEU VENC. APOS VENC SOMENTE NO(A) {0}, MULTA " +
                   "{1} MAIS MORA DE {2} AM. SR. CAIXA, NÃO RECEBER APÓS {3} DIAS DO VENCIMENTO.", nomeBanco, multa, juros, limiteDias);
            }

            return mensagem;
        }

        private void GeraArquivo(List<BoletoBancario> listaBoletosBancarios, List<int> listaIdDocFinanceiro)
        {
            Excel.Application objExcel = new Excel.ApplicationClass();
            Excel.Workbook objWB;
            Excel.Worksheet objSheet;
            Excel.Range objRange;
            object missing = Missing.Value;
            try
            {
// Tratamento de localidade:
// Se o excel que estiver usando for em inglês
// mas a configuração regional for de outra área,
// dispara a seguinte exceção:
// “Old format or invalid type library”
// Segundo a Microsoft o problema será resolvido
// a partir da versão 4.0 do .Net Framework
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-br");
// Instanciando objetos da interoperabilidade com Excel.
                objExcel.DisplayAlerts = false;
                objExcel.Visible = true;

                objWB = objExcel.Workbooks.Add(Missing.Value);
// Selecionando a primeira planilha
                objSheet = objWB.Worksheets.get_Item(1) as Excel.Worksheet;
// Adicionando título das colunas a partir da 4a. linha
                objSheet.Cells[1, 1] = "Beneficiário";
                objSheet.Cells[1, 2] = "Doc Financeiro";
                objSheet.Cells[1, 3] = "Valor Total";
                objSheet.Cells[1, 4] = "Codigo de Barras";
                objSheet.Cells[1, 5] = "IPTE";

// Atribuindo valores às células
                for (int i = 0; i < listaBoletosBancarios.Count; i++)
                {
                    objSheet.Cells[i + 2, 1] = listaBoletosBancarios[i].Boleto.Sacado.Nome;
                    objSheet.Cells[i + 2, 2] = listaIdDocFinanceiro[i];
                    objSheet.Cells[i + 2, 3] = listaBoletosBancarios[i].Boleto.ValorCobrado;
                    objRange = objSheet.get_Range("D" + (i+2), "D" + (i+2));
                    objRange.ClearFormats();
                    objRange.NumberFormat = ("#").PadRight(listaBoletosBancarios[i].Boleto.CodigoBarra.Codigo.Length, '#');
                    objSheet.Cells[i + 2, 4] = "." + listaBoletosBancarios[i].Boleto.CodigoBarra.Codigo + ".";
                    objSheet.Cells[i + 2, 5] = listaBoletosBancarios[i].Boleto.CodigoBarra.LinhaDigitavel;
                }

                objExcel.Columns.AutoFit();

// Salvo a planilha em um lugar no disco.
                objWB.SaveAs(Application.StartupPath +"\\Boletos.xls",Excel.XlFileFormat.xlWorkbookNormal,
                                missing, missing, missing, missing, Excel.XlSaveAsAccessMode.xlShared,
                                missing, missing, missing, missing, missing);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
// Fechando a planilha e liberando o Excel da memória
                objExcel.Quit();
                Marshal.ReleaseComObject(objExcel);
            }
        }

        private void GeraLayout(List<BoletoBancario> boletos)
        {
            StringBuilder html = new StringBuilder();
            foreach (BoletoBancario o in boletos)
            {
                html.Append(o.MontaHtml());
                html.Append("</br></br></br></br>");

                if (radioButton4.Checked)
                {
                    _arquivo = Path.GetTempFileName();
                    using (FileStream f = new FileStream(_arquivo, FileMode.Create))
                    {
                        StreamWriter w = new StreamWriter(f, System.Text.Encoding.Default);
                        w.Write(o.MontaHtml());
                        w.Close();
                        f.Close();
                    }
                    Imprimir();
                    CriarArquivo.ExluirArquivo(_arquivo);
                    //CriarArquivo.ExluirArquivo(Path.ChangeExtension(_arquivo, "bmp"));
                    _arquivo = string.Empty;
                }
            }

            _arquivo = Path.GetTempFileName();

            using (FileStream f = new FileStream(_arquivo, FileMode.Create))
            {
                StreamWriter w = new StreamWriter(f, System.Text.Encoding.Default);
                w.Write(html.ToString());
                w.Close();
                f.Close();
            }
        }

        #region Eventos do BackgroundWorker
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GeraBoleto();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _progresso.Close();

            // Cria um formulário com um componente WebBrowser dentro
            _impressaoBoleto = new ImpressaoBoleto();
            _impressaoBoleto.Arquivo = radioButton5.Checked ? "" : _arquivo;
            _impressaoBoleto.Impressao = radioButton4.Checked;
            _impressaoBoleto.NaoVisualizar = radioButton5.Checked;
            _impressaoBoleto.FormClosed += new FormClosedEventHandler(_impressaoBoleto_FormClosed);
            _impressaoBoleto.webBrowser.Navigate(_arquivo);
            _impressaoBoleto.MdiParent = this.MdiParent;
            _impressaoBoleto.Show();
        }
        #endregion Eventos do BackgroundWorker

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();

            _progresso = new Progresso();
            _progresso.ShowDialog();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                textBox1.Text = string.Empty;
                textBox1.Visible = true;
                label1.Visible = true;
                label2.Visible = true; 
                label2.Text = string.Empty;
            }
            else
            {
                textBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false; 
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, new EventArgs());
            }
        }

        private void Imprimir()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DocumentName = Path.GetFileNameWithoutExtension(_arquivo);
            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument.Print();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //This part sets up the data to be printed
            Graphics g = e.Graphics;
            Image image = new Bitmap(GerarImagem());
            //Makes the file to print and sets the look of it
            g.DrawImage(image, 10, 10);
        }
        
        private string GerarImagem()
        {
            string address = _arquivo;
            int width = 670;
            int height = 805;

            int webBrowserWidth = 670;
            int webBrowserHeight = 805;

            Bitmap bmp = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height);

            string file = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(_arquivo) + ".bmp");

            bmp.Save(file);

            return file;
        }
    }
}