clc;clear all;close all
%% initializing

global PLOT TRAJECTORY DP_Setting TRANSIENT_TRAJECTORY  Global_trj Length_Data
global Pd Update_Time MAX_TRJ Min_Range_Spheral_Cordinate
global Global_ID_TRANSIENT_TRAJECTORY  min_time max_time
global MAX_NUM_SCAN_CLUTTER_MAP Max_Range_CM Max_Azimuth_CM Max_Elevation_CM
global CMRangeCell CMAzimuthCell CMElevationCell Min_Speed Active_Target_Num last_Active_Target_Num
global ProgramCounter globalID ISPLOT
ISPLOT = false;
data = [];
counter = 1;
ProgramCounter=0;
globalID = 1;
while (ProgramCounter<100)
%while (ProgramCounter<2)
    ProgramCounter = ProgramCounter+1;
%     clear Global_trj;
    if ISPLOT
        hold off;
    end
    PLOT = struct('Range',0,'Azimuth',0,'Elevation',0,'Amp',0,'Time',0,'Id', 0,'Enable',0) ;
    tPos = struct('Range', 0,'Azimuth',0,'Elevation',0,'Speed',0,'CRS',0,'diffRange',0) ;
    
    TRAJECTORY = struct('tPos', tPos,'ID',0,'nConf',0,'nMiss',0) ;
    
    DP_Setting = struct('Scan_Time',0,'Current_Scan',0,'Prev_Scan',0,'Target_Num',0,'Transient_Target_Num',0,'Max_Target_Num',0,'Max_Target_Speed',0,'Current_ID',0);
 
    Length_Data = randi([10,100]);
    %Length_Data ( randi([10,30]))=;
    Active_Target_Num = randi(15);
    %Active_Target_Num = 2;
    last_Active_Target_Num = Active_Target_Num;
    Max_Clutter_Num = 0;randi(100);
    
    
    Apply_Miss_Detection = 1;
    Pd_For_Simulator = 0.9;
    Update_Time = 5;
    Pd = 0.99;
    MAX_TRJ = 30;
    MAX_SPEED = 40; % m/s
    Min_Speed = 1;
    Min_Range_Spheral_Cordinate = 0000;
    min_time = -1;
    max_time = 0;
    Global_ID_TRANSIENT_TRAJECTORY = 0;
    MAX_NUM_SCAN_CLUTTER_MAP = 15;
    Scan_Num = 0;
    Max_Range = 300000;
    Max_Range_CM = 300e3;
    Max_Azimuth_CM = 180;
    Max_Elevation_CM = 45;
    CMRangeCell = 7.5;
    CMAzimuthCell = 5;
    CMElevationCell = 1.3;
    for m=1:Length_Data
        % Length_Data=100
        Global_trj(1,m).trj(1:MAX_TRJ) = struct(TRAJECTORY);
    end
    
    %% Load data and extract plots
    Generate_Simulator_Data();
    scan_num = Length_Data;
    data = [];
    y = ProgramCounter;
    for x = 1:Active_Target_Num
        data(:,1) = Target_Azimuth(x,:);
        data(:,2) = Target_Range(x,:);
        name = strcat('data/',string(y),'-',string(x),'.txt');
        csvwrite(name,data);
    end
    
    %% apply trajectory
    if ISPLOT
        for i=1:scan_num
            current_scan_plots = struct(PLOT);
            
            Plot_Num = 0;
            for j=1:(Active_Target_Num + Max_Clutter_Num)
                % target
                if Target_Range(j,i) > 0 % if is zero, data is missed
                    Plot_Num                                  = Plot_Num + 1;
                    current_scan_plots(Plot_Num).Range        = Target_Range(j,i);
                    current_scan_plots(Plot_Num).Azimuth      = Target_Azimuth(j,i);
                    current_scan_plots(Plot_Num).Elevation    = Target_Elevation(j,i);
                    current_scan_plots(Plot_Num).Time         = Update_Time * i;
                    current_scan_plots(Plot_Num).Amp          = 20;
                    current_scan_plots(Plot_Num).Enable       = 1;
                    current_scan_plots(j).Id                  = -1;
                    
                end
            end
            num_plot_in_scan(i) = Plot_Num;
            scan_time(i) = Update_Time;
            
            System_Data_Process_Plots.TWS_Plots = current_scan_plots;
            System_Data_Process_Plots.TWS_Plot_Index = num_plot_in_scan(i);
            if System_Data_Process_Plots.TWS_Plot_Index > 5000
                System_Data_Process_Plots.TWS_Plot_Index = 0;
            end
            num_plot = 0;
            num_plot = System_Data_Process_Plots.TWS_Plot_Index;
            out_plot = System_Data_Process_Plots.TWS_Plots;
            Scan_Num = Scan_Num + 1;
            Scan_Num;
            
            rng = [];azm = [];elv = [];time = [];cntr = 0;
            for p=1:num_plot
               
                cntr = cntr + 1;
                if out_plot(p).Azimuth > 180
                    out_plot(p).Azimuth = out_plot(p).Azimuth - 360;
                end
                rng(cntr) = out_plot(p).Range;
                azm(cntr) = out_plot(p).Azimuth;
                elv(cntr) = out_plot(p).Elevation;
                time(cntr) = out_plot(p).Time;
                
            end
            %     figure(1);plot(azm,rng/1000,'.b');hold on;grid on;xlabel('Azimuth'),ylabel('Range')
            %     figure(2);plot(time,rng/1000,'.b');hold on;grid on;title('range'),xlabel('time'),ylabel('range')
            %     figure(3);plot(time,azm,'.b');hold on;grid on;title('azimuth'),xlabel('time'),ylabel('azimuth')
            %     figure(4);plot(rng/1000,elv,'.b');hold on;grid on;title('elv'),xlabel('rng'),ylabel('elv')
            %     figure(5);polar(azm*pi/180,rng,'.b');hold on;grid on;title('elv'),xlabel('rng'),ylabel('elv')
            
            %       hold off;
            figure(125)
            polar(0,300000);hold on
            polar(azm*pi/180,rng,'.b');hold on;grid on;title('elv'),xlabel('rng'),ylabel('elv')
            globalIDIndex = globalID - Active_Target_Num;
            for l=1:Active_Target_Num
                polar(Global_trj(i).trj(globalIDIndex).tPos.Azimuth*pi/180,Global_trj(i).trj(globalIDIndex).tPos.Range,'sr');hold on;grid on
               
                globalIDIndex = globalIDIndex + 1;
            end
            
            
            %  pause(.0001)
            %     close all
        end
    end
end