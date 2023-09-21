function model = trainSVM(X, y)
    % Initialise function
    w = zeros(1, length(y));
    b = 0;
    epochs = 200; % 200 data point epoch
    alpha = 0.01;

    % Training
    for epoch = 1:epochs
        for i = 1:length(y)
            condition = y(i) * (dot(w, X(1, i)) + b) >= 1;
            if condition
                w = w - alpha * (2 * 1/epoch * w);
            else
                w = w + alpha * (y(i) * X(i, :) - 2 * 1/epoch * w);
                b = b + alpha * y(i);
            end
        end
    end
    model = struct('w', w, 'b', b);
end
