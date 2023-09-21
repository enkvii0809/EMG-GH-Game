%% Step 1: Get the MU filters from all the edited files and concatenate them 


files = dir('Decomp_edited');

MUfilters = []; % Create an empty matrix for the concatenation of filters
for i = 3:size(files,1)
    load(files(i).name, 'signal', 'edition') % Load the edited discharge times and signals
    for j = 1:size(edition.Pulsetrain{1})
        distime{j} = edition.Dischargetimes{1,j}; % Reformat the discharge times
    end
    filters = getMUfilters(signal.data(1:64,:), signal.EMGmask{1}, distime); % Get the MU filters
    MUfilters = [MUfilters, filters]; % Concatenate the filters
end
clearvars filters distime signal edition

%% % Specify the directory where your files are located
directory = 'Decomp_edited';
files = dir(fullfile(directory, '*.mat')); 
MUfilters = []; 
distime = [];

for i = 1:numel(files)

    load(fullfile('Decomp_edited', files(i).name), 'signal', 'edition') 
        
    for j = 1:size(edition.Pulsetrain{1})
            distime{i}{j} = edition.Dischargetimes{1,j};
    end
        
  
    filters = getMUfilters(signal.data(1:64,:), signal.EMGmask{1}, distime{i});
    MUfilters = [MUfilters, filters];
        
end

clearvars filters signal edition;


%% Step 2: Automatic identification of MUs on all the files

files = dir('Decomp_edited');
EMG = [];
finger = [];
for i = 3:size(files,1) % Concatenate the EMG signals
    load(files(i).name, 'signal') % Load the edited discharge times and signals
    EMG = [EMG, signal.data(1:64,:)];
    finger = [finger, ones(1,size(signal.data,2))*i];
end

% Reorganize the EMG signal according to their position on the grid
% Differentiate the EMG signal with a bipolar montage (input #1 for the
% decoder)
[EMGdiff, ~] = getSIGdiff(EMG, signal.coordinates{1}, signal.EMGmask{1});

% Get the motor unit pulse trains and discharge times from all the files
[PulseT, Distime, ~] = getPulseT(EMG, signal.EMGmask{1}, MUfilters, signal.fsamp);

% Filter the discharge times to get smoothed discharge rates (input #2 for
% the decoder)

win = 2/round(signal.fsamp*0.4)*hann(round(signal.fsamp*0.4));
firings = zeros(size(PulseT));
smoothfirings = zeros(size(PulseT));
for i = 1:length(Distime)
    firings(i, Distime{i}) = 1;
    smoothfirings(i,:) = conv(firings(i,:), win, 'same');
end
%% Separating