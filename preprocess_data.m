function filtered_data = preprocess_data(emg_data, gain)
    fs = 1200;
    lowcut = 20;
    highcut = 500;
    order = 2;

    % Notch filter
    f0 = 50;
    Q = 30;
    w0 = f0 / (fs / 2);
    bw = w0 / Q;
    [b_notch, a_notch] = iirnotch(w0, bw);

    % Bandpass filter
    nyquist_freq = 0.5 * fs;
    low = lowcut / nyquist_freq;
    high = highcut / nyquist_freq;
    [b_butter, a_butter] = butter(order, [low, high], 'bandpass');

    % Apply filtering 
    filtered_data = zeros(size(emg_data));
    for i = 1:size(emg_data, 2)
        channel_data = gain * emg_data(:, i);  % Apply gain

        % Masks to remove NaN/Inf values
        nan_mask = isnan(channel_data);
        channel_data(nan_mask) = 0;

        inf_mask = isinf(channel_data);
        channel_data(inf_mask) = 0;
            
        
        filtered_data(:, i) = filtfilt(b_notch, a_notch, channel_data);
        filtered_data(:, i) = filtfilt(b_butter, a_butter, filtered_data(:, i));
    end
end
